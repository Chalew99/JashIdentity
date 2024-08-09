 
 


using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Configuration;

/// <summary>
/// Interface for communication with the client configuration data store.
/// </summary>
public interface IClientConfigurationStore
{
    /// <summary>
    /// Adds a client to the configuration store.
    /// </summary>
    /// <param name="client">The client to add to the store</param>
    Task AddAsync(Client client);
}
