


using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Validation result for API validation
/// </summary>
public class ApiSecretValidationResult : ValidationResult
{
    /// <summary>
    /// Gets or sets the resource.
    /// </summary>
    /// <value>
    /// The resource.
    /// </value>
    public ApiResource Resource { get; set; }
}