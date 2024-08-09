


#nullable enable

using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Class describing the extension grant validation context
/// </summary>
public class ExtensionGrantValidationContext
{
    /// <summary>
    /// Gets or sets the request.
    /// </summary>
    /// <value>
    /// The request.
    /// </value>
    public ValidatedTokenRequest Request { get; set; } = default!;

    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>
    /// The result.
    /// </value>
    public GrantValidationResult Result { get; set; } = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
}
