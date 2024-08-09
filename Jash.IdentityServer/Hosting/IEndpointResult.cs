


using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Hosting;

/// <summary>
/// An <see cref="IEndpointResult"/> is the object model that describes the
/// results that will returned by one of the protocol endpoints provided by
/// IdentityServer, and can be executed to produce an HTTP response.
/// </summary>
public interface IEndpointResult
{
    /// <summary>
    /// Executes the result to write an http response.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    Task ExecuteAsync(HttpContext context);
}

