 
 


using Jash.IdentityServer.Models;
using Jash.IdentityServer.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Hosting.DynamicProviders;

class NopIdentityProviderStore : IIdentityProviderStore
{
    public Task<IEnumerable<IdentityProviderName>> GetAllSchemeNamesAsync()
    {
        return Task.FromResult(Enumerable.Empty<IdentityProviderName>());
    }

    public Task<IdentityProvider> GetBySchemeAsync(string scheme)
    {
        return Task.FromResult<IdentityProvider>(null);
    }
}
