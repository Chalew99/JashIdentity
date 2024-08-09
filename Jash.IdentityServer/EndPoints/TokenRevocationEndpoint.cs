


using IdentityModel;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using Jash.IdentityServer.Endpoints.Results;
using Jash.IdentityServer.Events;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.ResponseHandling;
using Jash.IdentityServer.Services;
using Jash.IdentityServer.Validation;
using Microsoft.AspNetCore.Http;
using Jash.IdentityServer.Extensions;
using System.IO;

namespace Jash.IdentityServer.Endpoints;

/// <summary>
/// The revocation endpoint
/// </summary>
/// <seealso cref="IEndpointHandler" />
internal class TokenRevocationEndpoint : IEndpointHandler
{
    private readonly ILogger _logger;
    private readonly IClientSecretValidator _clientValidator;
    private readonly ITokenRevocationRequestValidator _requestValidator;
    private readonly ITokenRevocationResponseGenerator _responseGenerator;
    private readonly IEventService _events;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenRevocationEndpoint" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="clientValidator">The client validator.</param>
    /// <param name="requestValidator">The request validator.</param>
    /// <param name="responseGenerator">The response generator.</param>
    /// <param name="events">The events.</param>
    public TokenRevocationEndpoint(ILogger<TokenRevocationEndpoint> logger,
        IClientSecretValidator clientValidator,
        ITokenRevocationRequestValidator requestValidator,
        ITokenRevocationResponseGenerator responseGenerator,
        IEventService events)
    {
        _logger = logger;
        _clientValidator = clientValidator;
        _requestValidator = requestValidator;
        _responseGenerator = responseGenerator;

        _events = events;
    }

    /// <summary>
    /// Processes the request.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns></returns>
    public async Task<IEndpointResult> ProcessAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.Revocation + "Endpoint");
        
        _logger.LogTrace("Processing revocation request.");

        if (!HttpMethods.IsPost(context.Request.Method))
        {
            _logger.LogWarning("Invalid HTTP method");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        if (!context.Request.HasApplicationFormContentType())
        {
            _logger.LogWarning("Invalid media type");
            return new StatusCodeResult(HttpStatusCode.UnsupportedMediaType);
        }

        try
        {
            return await ProcessRevocationRequestAsync(context);
        }
        catch (InvalidDataException ex)
        {
            _logger.LogWarning(ex, "Invalid HTTP request for revocation endpoint");
            return new StatusCodeResult(HttpStatusCode.BadRequest);
        }
    }

    private async Task<IEndpointResult> ProcessRevocationRequestAsync(HttpContext context)
    {
        _logger.LogDebug("Start revocation request.");

        // validate client
        var clientValidationResult = await _clientValidator.ValidateAsync(context);
        if (clientValidationResult.IsError)
        {
            var error = clientValidationResult.Error ?? OidcConstants.TokenErrors.InvalidClient;
            Telemetry.Metrics.RevocationFailure(clientValidationResult.Client?.ClientId, error);
            return new TokenRevocationErrorResult(error);
        }

        _logger.LogTrace("Client validation successful");

        // validate the token request
        var form = (await context.Request.ReadFormAsync()).AsNameValueCollection();

        _logger.LogTrace("Calling into token revocation request validator: {type}", _requestValidator.GetType().FullName);
        var requestValidationResult = await _requestValidator.ValidateRequestAsync(form, clientValidationResult.Client);

        if (requestValidationResult.IsError)
        {
            Telemetry.Metrics.RevocationFailure(clientValidationResult.Client.ClientId, requestValidationResult.Error);
            return new TokenRevocationErrorResult(requestValidationResult.Error);
        }

        _logger.LogTrace("Calling into token revocation response generator: {type}", _responseGenerator.GetType().FullName);
        var response = await _responseGenerator.ProcessAsync(requestValidationResult);

        if (response.Success)
        {
            _logger.LogInformation("Token revocation complete");
            Telemetry.Metrics.Revocation(clientValidationResult.Client.ClientId);
            await _events.RaiseAsync(new TokenRevokedSuccessEvent(requestValidationResult, requestValidationResult.Client));
        }
        else
        {
            _logger.LogInformation("No matching token found");
        }

        if (response.Error.IsPresent()) return new TokenRevocationErrorResult(response.Error);

        return new StatusCodeResult(HttpStatusCode.OK);
    }
}