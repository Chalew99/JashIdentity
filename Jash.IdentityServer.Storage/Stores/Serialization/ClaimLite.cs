 
 


#pragma warning disable 1591

namespace Jash.IdentityServer.Stores.Serialization;

public class ClaimLite
{
    public string Type { get; set; }
    public string Value { get; set; }
    public string ValueType { get; set; }
}