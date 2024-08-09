


using System.Collections.Generic;
using System.Threading.Tasks;
using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Stores;

/// <summary>
/// Interface for the validation key store
/// </summary>
public interface IValidationKeysStore
{
    /// <summary>
    /// Gets all validation keys.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SecurityKeyInfo>> GetValidationKeysAsync();
}