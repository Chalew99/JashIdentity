 
 


using Jash.IdentityServer.Services;
using System.Threading;

namespace Jash.IdentityServer.Services;

/// <summary>
/// Implementation of ICancellationTokenProvider that returns CancellationToken.None
/// </summary>
public class NoneCancellationTokenProvider : ICancellationTokenProvider
{
    /// <inheritdoc/>
    public CancellationToken CancellationToken => CancellationToken.None;
}