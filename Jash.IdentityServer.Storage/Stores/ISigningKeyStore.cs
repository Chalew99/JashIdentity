 
 


#nullable enable

using Jash.IdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Stores;

/// <summary>
/// Interface to model storage of serialized keys.
/// </summary>
public interface ISigningKeyStore
{
    /// <summary>
    /// Returns all the keys in storage.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SerializedKey>> LoadKeysAsync();

    /// <summary>
    /// Persists new key in storage.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task StoreKeyAsync(SerializedKey key);

    /// <summary>
    /// Deletes key from storage.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteKeyAsync(string id);
}
