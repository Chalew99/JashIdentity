


using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Services.KeyManagement;

/// <summary>
/// Interface to model protecting/unprotecting RsaKeyContainer.
/// </summary>
public interface ISigningKeyProtector
{
    /// <summary>
    /// Protects KeyContainer.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    SerializedKey Protect(KeyContainer key);

    /// <summary>
    /// Unprotects KeyContainer.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    KeyContainer Unprotect(SerializedKey key);
}