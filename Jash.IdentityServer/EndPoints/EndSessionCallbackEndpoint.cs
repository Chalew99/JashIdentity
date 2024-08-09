


using System.Net;
using System.Threading.Tasks;
using Jash.IdentityServer.Endpoints.Results;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.Validation;
using Jash.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Jash.IdentityServer.Endpoints;

internal class EndSessionCallbackEndpoint : IEndpointHandler
{
    private readonly IEndSessionRequestValidator _endSessionRequestValidator;
    private readonly ILogger _logger;

    public EndSessionCallbackEndpoint(
        IEndSessionRequestValidator endSessionRequestValidator,
        ILogger<EndSessionCallbackEndpoint> logger)
    {
        _endSessionRequestValidator = endSessionRequestValidator;
        _logger = logger;
    }

    public async Task<IEndpointResult> ProcessAsync(HttpContext context)
    {
        using var activity = Tracing.BasicActivitySource.StartActivity(IdentityServerConstants.EndpointNames.EndSession + "CallbackEndpoint");
        
        if (!HttpMethods.IsGet(context.Request.Method))
        {
            _logger.LogWarning("Invalid HTTP method for end session callback endpoint.");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        _logger.LogDebug("Processing signout callback request");

        var parameters = context.Request.Query.AsNameValueCollection();
        var result = await _endSessionRequestValidator.ValidateCallbackAsync(parameters);

        if (!result.IsError)
        {
            _logger.LogInformation("Successful signout callback.");
        }
        else
        {
            _logger.LogError("Error validating signout callback: {error}", result.Error);
        }
            
        return new EndSessionCallbackResult(result);
    }
}
