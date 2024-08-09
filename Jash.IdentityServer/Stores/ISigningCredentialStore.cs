


using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Jash.IdentityServer.Stores;

/// <summary>
/// Interface for a signing credential store
/// </summary>
public interface ISigningCredentialStore
{
    /// <summary>
    /// Gets the signing credentials.
    /// </summary>
    /// <returns></returns>
    Task<SigningCredentials> GetSigningCredentialsAsync();
}