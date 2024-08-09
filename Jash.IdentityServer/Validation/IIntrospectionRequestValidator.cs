

using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Interface for the introspection request validator
/// </summary>
public interface IIntrospectionRequestValidator
{
    /// <summary>
    /// Validates the request.
    /// </summary>
    Task<IntrospectionRequestValidationResult> ValidateAsync(IntrospectionRequestValidationContext context);
}

