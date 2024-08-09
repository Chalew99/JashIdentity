


#nullable enable

using Jash.IdentityServer.Models;
using Jash.IdentityServer.Validation;

namespace Jash.IdentityServer.Models;

/// <summary>
/// Represents contextual information about a device flow authorization request.
/// </summary>
public class DeviceFlowAuthorizationRequest
{
    /// <summary>
    /// Gets or sets the client.
    /// </summary>
    /// <value>
    /// The client.
    /// </value>
    public Client Client { get; set; } = default!;

    /// <summary>
    /// Gets or sets the validated resources.
    /// </summary>
    /// <value>
    /// The scopes requested.
    /// </value>
    public ResourceValidationResult ValidatedResources { get; set; } = default!;
}
