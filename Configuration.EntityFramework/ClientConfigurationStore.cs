 
 


using Jash.IdentityServer.EntityFramework.DbContexts;
using Jash.IdentityServer.EntityFramework.Mappers;
using Jash.IdentityServer.Models;
using Jash.IdentityServer.Services;
using Microsoft.Extensions.Logging;

namespace Jash.IdentityServer.Configuration;

/// <summary>
/// Communicates with the client configuration data store using entity
/// framework. 
/// </summary>
public class ClientConfigurationStore : IClientConfigurationStore
{
    /// <summary>
    /// The DbContext.
    /// </summary>
    protected readonly ConfigurationDbContext DbContext;

    /// <summary>
    /// The CancellationToken provider.
    /// </summary>
    protected readonly ICancellationTokenProvider CancellationTokenProvider;

    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<ClientConfigurationStore> Logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientConfigurationStore"/>
    /// class.
    /// </summary>
    public ClientConfigurationStore(
        ConfigurationDbContext dbContext,
        ICancellationTokenProvider cancellationTokenProvider,
        ILogger<ClientConfigurationStore> logger)
    {
        DbContext = dbContext;
        CancellationTokenProvider = cancellationTokenProvider;
        Logger = logger;
    }

    /// <inheritdoc />
    public async Task AddAsync(Client client)
    {
        Logger.LogDebug("Adding client {clientId} to configuration store", client.ClientId);
        DbContext.Clients.Add(ClientMappers.ToEntity(client));
        await DbContext.SaveChangesAsync(CancellationTokenProvider.CancellationToken);
    }
}
