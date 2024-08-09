


using System.Collections.Specialized;
using System.Threading.Tasks;
using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Interface for the token revocation request validator
/// </summary>
public interface ITokenRevocationRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <param name="client">The client.</param>
    /// <returns></returns>
    Task<TokenRevocationRequestValidationResult> ValidateRequestAsync(NameValueCollection parameters, Client client);
}