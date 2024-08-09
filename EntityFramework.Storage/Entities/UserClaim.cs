 
 


#pragma warning disable 1591

namespace Jash.IdentityServer.EntityFramework.Entities;

public abstract class UserClaim
{
    public int Id { get; set; }
    public string Type { get; set; }
}