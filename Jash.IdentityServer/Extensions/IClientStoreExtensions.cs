 
 


using Jash.IdentityServer.Models;
using Jash.IdentityServer.Stores;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Stores;

/// <summary>
/// Extension for IClientStore
/// </summary>
public static class IClientStoreExtensions
{
    /// <summary>
    /// Finds the enabled client by identifier.
    /// </summary>
    /// <param name="store">The store.</param>
    /// <param name="clientId">The client identifier.</param>
    /// <returns></returns>
    public static async Task<Client> FindEnabledClientByIdAsync(this IClientStore store, string clientId)
    {
        var client = await store.FindClientByIdAsync(clientId);
        if (client != null && client.Enabled) return client;

        return null;
    }
}