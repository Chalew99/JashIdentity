


using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Interface for the token request validator
/// </summary>
public interface ITokenRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    Task<TokenRequestValidationResult> ValidateRequestAsync(TokenRequestValidationContext context);
}