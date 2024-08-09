


#nullable enable

using System.Threading.Tasks;
using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Services;

/// <summary>
/// The service responsible for performing back-channel logout notification.
/// </summary>
public interface IBackChannelLogoutService
{
    /// <summary>
    /// Performs http back-channel logout notification.
    /// </summary>
    /// <param name="context">The context of the back channel logout notification.</param>
    Task SendLogoutNotificationsAsync(LogoutNotificationContext context);
}
