 
 


#pragma warning disable 1591

namespace Jash.IdentityServer.EntityFramework.Entities;

public class ApiResourceProperty : Property
{
    public int ApiResourceId { get; set; }
    public ApiResource ApiResource { get; set; }
}