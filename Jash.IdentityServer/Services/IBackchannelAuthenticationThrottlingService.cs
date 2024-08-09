


#nullable enable

using System.Threading.Tasks;
using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Services;

/// <summary>
/// The backchannel authentication throttling service.
/// </summary>
public interface IBackchannelAuthenticationThrottlingService
{
    /// <summary>
    /// Decides if the requesting client and request needs to slow down.
    /// </summary>
    Task<bool> ShouldSlowDown(string requestId, BackChannelAuthenticationRequest details);
}
