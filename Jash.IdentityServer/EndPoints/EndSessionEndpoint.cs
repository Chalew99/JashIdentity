


using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Jash.IdentityServer.Endpoints.Results;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.Services;
using Jash.IdentityServer.Validation;
using Jash.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Jash.IdentityServer.Endpoints;

internal class EndSessionEndpoint : IEndpointHandler
{
    private readonly IEndSessionRequestValidator _endSessionRequestValidator;

    private readonly ILogger _logger;

    private readonly IUserSession _userSession;

    public EndSessionEndpoint(
        IEndSessionRequestValidator endSessionRequestValidator,
        IUserSession userSession,
        ILogger<EndSessionEndpoint> logger)
    {
        _endSessionRequestValidator = endSessionRequestValidator;
        _userSession = userSession;
        _logger = logger;
    }

    public async Task<IEndpointResult> ProcessAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.EndSession + "Endpoint");

        try
        {
            return await ProcessEndSessionAsync(context);
        }
        catch (InvalidDataException ex)
        {
            _logger.LogWarning(ex, "Invalid HTTP request for end session endpoint");
            return new StatusCodeResult(HttpStatusCode.BadRequest);
        }
    }


    async Task<IEndpointResult> ProcessEndSessionAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.EndSession + "Endpoint");

        NameValueCollection parameters;
        if (HttpMethods.IsGet(context.Request.Method))
        {
            parameters = context.Request.Query.AsNameValueCollection();
        }
        else if (HttpMethods.IsPost(context.Request.Method))
        {
            parameters = (await context.Request.ReadFormAsync()).AsNameValueCollection();
        }
        else
        {
            _logger.LogWarning("Invalid HTTP method for end session endpoint.");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        var user = await _userSession.GetUserAsync();

        _logger.LogDebug("Processing signout request for {subjectId}", user?.GetSubjectId() ?? "anonymous");

        var result = await _endSessionRequestValidator.ValidateAsync(parameters, user);

        if (result.IsError)
        {
            _logger.LogError("Error processing end session request {error}", result.Error);
        }
        else
        {
            _logger.LogDebug("Success validating end session request from {clientId}", result.ValidatedRequest?.Client?.ClientId);
        }

        return new EndSessionResult(result);
    }
}
