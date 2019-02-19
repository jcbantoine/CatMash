using EntityMash.Models;
using System;
using System.Collections.Generic;

namespace EntityMash.Services.Interop
{
    /// <summary>
    /// This interface describe what's an entity mash service.
    /// </summary>
    public interface IEntityMashService
    {
        /// <summary>
        /// Get two random entities. 
        /// </summary>
        /// <returns></returns>
        Tuple<Entity, Entity> GetVersus();
        /// <summary>
        /// Get a ranking of all entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entity> GetRanking();
        /// <summary>
        /// Add vote for an entity.
        /// </summary>
        /// <param name="entity"></param>
        void AddVote(string identifier);
    }
}