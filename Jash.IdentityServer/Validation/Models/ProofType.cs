


using Jash.IdentityServer.Models;

namespace Jash.IdentityServer.Validation;

/// <summary>
/// Models the thumbprint of a proof key
/// </summary>
public class ProofKeyThumbprint
{
    /// <summary>
    /// The type
    /// </summary>
    public ProofType Type { get; set; }
    /// <summary>
    /// The thumbprint value used in a cnf thumbprint claim value
    /// </summary>
    public string Thumbprint { get; set; }
}
