


using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Extensibility point for CIBA authentication request validation.
/// </summary>
public interface ICustomBackchannelAuthenticationValidator
{
    /// <summary>
    /// Validates a CIBA authentication request.
    /// </summary>
    /// <param name="customValidationContext"></param>
    /// <returns></returns>
    Task ValidateAsync(CustomBackchannelAuthenticationRequestValidationContext customValidationContext);
}
