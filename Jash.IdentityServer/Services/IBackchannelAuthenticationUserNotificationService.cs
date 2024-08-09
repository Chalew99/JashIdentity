


#nullable enable

using Jash.IdentityServer.Models;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Services;

/// <summary>
/// Interface for sending a user a login request from a backchannel authentication request.
/// </summary>
public interface IBackchannelAuthenticationUserNotificationService
{
    /// <summary>
    /// Sends a notification for the user to login.
    /// </summary>
    Task SendLoginRequestAsync(BackchannelUserLoginRequest request);
}
