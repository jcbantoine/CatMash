using EntityMash.Models;
using System.Collections.Generic;

namespace EntityMash.Services.Interop
{
    /// <summary>
    /// This interface describe what's an entities repository.
    /// </summary>
    public interface IEntitiesRepository
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        IEnumerable<Entity> Entities { get; }
        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(Entity entity);
    }
}
