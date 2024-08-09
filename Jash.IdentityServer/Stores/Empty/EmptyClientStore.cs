


using Jash.IdentityServer.Models;
using Jash.IdentityServer.Stores;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Stores.Empty;

internal class EmptyClientStore : IClientStore
{
    public Task<Client> FindClientByIdAsync(string clientId)
    {
        return Task.FromResult<Client>(null);
    }
}

