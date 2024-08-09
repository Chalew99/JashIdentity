

using System.Threading.Tasks;

namespace Jash.IdentityServer.Internal;

/// <summary>
/// Nop implementation.
/// </summary>
public class NopConcurrencyLock<T> : IConcurrencyLock<T>
{
    /// <inheritdoc/>
    public Task<bool> LockAsync(int millisecondsTimeout)
    {
        return Task.FromResult(true);
    }

    /// <inheritdoc/>
    public void Unlock()
    {
    }
}