


using System.Threading.Tasks;
using Jash.IdentityServer.Hosting;
using Microsoft.AspNetCore.Http;
using Jash.IdentityServer.Extensions;

namespace Jash.IdentityServer.Endpoints.Results;

/// <summary>
/// The result of a bad request
/// </summary>
public class BadRequestResult : EndpointResult<BadRequestResult>
{
    /// <summary>
    /// The error
    /// </summary>
    public string Error { get; }
    /// <summary>
    /// The error description
    /// </summary>
    public string ErrorDescription { get; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="error"></param>
    /// <param name="errorDescription"></param>
    public BadRequestResult(string error = null, string errorDescription = null)
    {
        Error = error;
        ErrorDescription = errorDescription;
    }
}

internal class BadRequestHttpWriter : IHttpResponseWriter<BadRequestResult>
{
    public async Task WriteHttpResponse(BadRequestResult result, HttpContext context)
    {
        context.Response.StatusCode = 400;
        context.Response.SetNoCache();

        if (result.Error.IsPresent())
        {
            var dto = new ResultDto
            {
                error = result.Error,
                error_description = result.ErrorDescription
            };

            await context.Response.WriteJsonAsync(dto);
        }
    }

    internal class ResultDto
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
}