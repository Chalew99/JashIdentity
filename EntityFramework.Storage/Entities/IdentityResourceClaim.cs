 
 


#pragma warning disable 1591

namespace Jash.IdentityServer.EntityFramework.Entities;

public class IdentityResourceClaim : UserClaim
{
    public int IdentityResourceId { get; set; }
    public IdentityResource IdentityResource { get; set; }
}