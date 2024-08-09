 
 


#pragma warning disable 1591

namespace Jash.IdentityServer.EntityFramework.Entities;

public class ClientProperty : Property
{
    public int ClientId { get; set; }
    public Client Client { get; set; }
}