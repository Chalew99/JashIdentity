


using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// The backchannel authentication request id validator
/// </summary>
public interface IBackchannelAuthenticationRequestIdValidator
{
    /// <summary>
    /// Validates the authentication request id.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    Task ValidateAsync(BackchannelAuthenticationRequestIdValidationContext context);
}