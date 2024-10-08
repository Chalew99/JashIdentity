

using System.Threading.Tasks;

namespace Jash.IdentityServer.Internal;

/// <summary>
/// Interface to model locking.
/// </summary>
public interface IConcurrencyLock<T>
{
    /// <summary>
    /// Locks. Returns false if lock was not obtained within in the timeout.
    /// </summary>
    /// <returns></returns>
    Task<bool> LockAsync(int millisecondsTimeout);

    /// <summary>
    /// Unlocks
    /// </summary>
    /// <returns></returns>
    void Unlock();
}