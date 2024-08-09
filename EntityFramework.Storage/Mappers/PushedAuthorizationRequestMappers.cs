 
 


using Jash.IdentityServer.EntityFramework.Entities;

namespace Jash.IdentityServer.EntityFramework.Mappers;

/// <summary>
/// Extension methods to map to/from entity/model for pushed authorization requests.
/// </summary>
public static class PushedAuthorizationRequestMappers
{
    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static Models.PushedAuthorizationRequest ToModel(this PushedAuthorizationRequest entity)
    {
        return entity == null ? null :
            new Models.PushedAuthorizationRequest
            {
                ReferenceValueHash = entity.ReferenceValueHash,
                ExpiresAtUtc = entity.ExpiresAtUtc,
                Parameters = entity.Parameters,
            };
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.PushedAuthorizationRequest ToEntity(this Models.PushedAuthorizationRequest model)
    {
        return model == null ? null : 
            new Entities.PushedAuthorizationRequest
            {
                ReferenceValueHash = model.ReferenceValueHash,
                ExpiresAtUtc = model.ExpiresAtUtc,
                Parameters = model.Parameters,
            };
    }
}
