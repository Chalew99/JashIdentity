


using System.Threading.Tasks;
using Jash.IdentityServer.Validation;

namespace Jash.IdentityServer.ResponseHandling;

/// <summary>
/// Interface for the device authorization response generator
/// </summary>
public interface IDeviceAuthorizationResponseGenerator
{
    /// <summary>
    /// Processes the response.
    /// </summary>
    /// <param name="validationResult">The validation result.</param>
    /// <param name="baseUrl">The base URL.</param>
    /// <returns></returns>
    Task<DeviceAuthorizationResponse> ProcessAsync(DeviceAuthorizationRequestValidationResult validationResult, string baseUrl);
}