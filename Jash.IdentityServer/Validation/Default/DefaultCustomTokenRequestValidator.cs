


using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Default custom request validator
/// </summary>
internal class DefaultCustomTokenRequestValidator : ICustomTokenRequestValidator
{
    /// <summary>
    /// Custom validation logic for a token request.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>
    /// The validation result
    /// </returns>
    public Task ValidateAsync(CustomTokenRequestValidationContext context)
    {
        return Task.CompletedTask;
    }
}