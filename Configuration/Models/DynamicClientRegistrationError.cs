 
 


using Jash.IdentityServer.Configuration.Models.DynamicClientRegistration;
using Jash.IdentityServer.Configuration.Validation.DynamicClientRegistration;

namespace Jash.IdentityServer.Configuration.Models;

/// <summary>
/// Represents an error during dynamic client registration.
/// </summary>
public class DynamicClientRegistrationError : IStepResult, IDynamicClientRegistrationResponse, IDynamicClientRegistrationValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="DynamicClientRegistrationError"/> class.
    /// </summary>
    /// <param name="error">The error code for the error that occurred. Error
    /// codes defined by RFC 7591 are defined as constants in the <see
    /// cref="DynamicClientRegistrationErrors" /> class.</param>
    /// <param name="errorDescription">A human-readable description of the error
    /// that occurred during validation or processing.</param>
    public DynamicClientRegistrationError(string error, string errorDescription)
    {
        Error = error;
        ErrorDescription = errorDescription;
    }

    /// <summary>
    /// Gets or sets the error code for the error that occurred. Error codes
    /// defined by RFC 7591 are defined as constants in the <see
    /// cref="DynamicClientRegistrationErrors" /> class.
    /// </summary>
    public string Error { get; set; }

    /// <summary>
    /// Gets or sets a human-readable description of the error that occurred.
    /// </summary>
    public string ErrorDescription { get; set; }
}
