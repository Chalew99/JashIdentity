


using System.Collections.Generic;
using System.Threading.Tasks;
using Jash.IdentityServer.Validation;

namespace Jash.IdentityServer.ResponseHandling;

/// <summary>
/// Interface for introspection response generator
/// </summary>
public interface IIntrospectionResponseGenerator
{
    /// <summary>
    /// Processes the response.
    /// </summary>
    /// <param name="validationResult">The validation result.</param>
    /// <returns></returns>
    Task<Dictionary<string, object>> ProcessAsync(IntrospectionRequestValidationResult validationResult);
}