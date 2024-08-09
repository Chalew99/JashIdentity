


using Jash.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.ResponseHandling;
using IdentityModel;

namespace Jash.IdentityServer.Endpoints.Results;

/// <summary>
/// Models the result of backchannel authentication 
/// </summary>
public class BackchannelAuthenticationResult : EndpointResult<BackchannelAuthenticationResult>
{
    /// <summary>
    /// The response
    /// </summary>
    public BackchannelAuthenticationResponse Response { get; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="response"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public BackchannelAuthenticationResult(BackchannelAuthenticationResponse response)
    {
        Response = response ?? throw new ArgumentNullException(nameof(response));
    }
}

internal class BackchannelAuthenticationHttpWriter : IHttpResponseWriter<BackchannelAuthenticationResult>
{
    public async Task WriteHttpResponse(BackchannelAuthenticationResult result, HttpContext context)
    {
        context.Response.SetNoCache();

        if (result.Response.IsError)
        {
            switch (result.Response.Error)
            {
                case OidcConstants.BackchannelAuthenticationRequestErrors.InvalidClient:
                    context.Response.StatusCode = 401;
                    break;
                case OidcConstants.BackchannelAuthenticationRequestErrors.AccessDenied:
                    context.Response.StatusCode = 403;
                    break;
                default:
                    context.Response.StatusCode = 400;
                    break;
            }

            await context.Response.WriteJsonAsync(new ErrorResultDto
            {
                error = result.Response.Error,
                error_description = result.Response.ErrorDescription
            });
        }
        else
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteJsonAsync(new SuccessResultDto
            {
                auth_req_id = result.Response.AuthenticationRequestId,
                expires_in = result.Response.ExpiresIn,
                interval = result.Response.Interval,
                
                Custom = result.Response.Custom
            });
        }
    }

    internal class SuccessResultDto
    {
#pragma warning disable IDE1006 // Naming Styles
        public string auth_req_id { get; set; }
        public int expires_in { get; set; }
        public int interval { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> Custom { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    internal class ErrorResultDto
    {
#pragma warning disable IDE1006 // Naming Styles
        public string error { get; set; }
        public string error_description { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}