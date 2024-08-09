


using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using Jash.IdentityServer.Hosting;
using Jash.IdentityServer.Extensions;

namespace Jash.IdentityServer.Endpoints.Results;

/// <summary>
/// Result for introspection
/// </summary>
/// <seealso cref="IEndpointResult" />
public class IntrospectionResult : EndpointResult<IntrospectionResult>
{
    /// <summary>
    /// Gets the result.
    /// </summary>
    /// <value>
    /// The result.
    /// </value>
    public Dictionary<string, object> Entries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntrospectionResult"/> class.
    /// </summary>
    /// <param name="entries">The result.</param>
    /// <exception cref="System.ArgumentNullException">result</exception>
    public IntrospectionResult(Dictionary<string, object> entries)
    {
        Entries = entries ?? throw new ArgumentNullException(nameof(entries));
    }
}


class IntrospectionHttpWriter : IHttpResponseWriter<IntrospectionResult>
{
    public Task WriteHttpResponse(IntrospectionResult result, HttpContext context)
    {
        context.Response.SetNoCache();

        return context.Response.WriteJsonAsync(result.Entries);
    }
}
