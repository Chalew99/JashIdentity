


using System.Collections.Generic;
using System.Threading.Tasks;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace Jash.IdentityServer.Endpoints.Results;

/// <summary>
/// The result of userinfo 
/// </summary>
public class UserInfoResult : EndpointResult<UserInfoResult>
{
    /// <summary>
    /// The claims
    /// </summary>
    public Dictionary<string, object> Claims { get; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="claims"></param>
    public UserInfoResult(Dictionary<string, object> claims)
    {
        Claims = claims ?? throw new ArgumentNullException(nameof(claims));
    }
}

internal class UserInfoHttpWriter : IHttpResponseWriter<UserInfoResult>
{
    public async Task WriteHttpResponse(UserInfoResult result, HttpContext context)
    {
        context.Response.SetNoCache();
        await context.Response.WriteJsonAsync(result.Claims);
    }
}