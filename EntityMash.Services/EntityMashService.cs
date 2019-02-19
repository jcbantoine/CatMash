using EntityMash.Models;
using EntityMash.Services.Interop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityMash.Services
{
    /// <summary>
    /// This class is an implementation of <see cref="IEntitiesRepository"/>
    /// </summary>
    public class EntityMashService : IEntityMashService
    {
        private IEntitiesRepository entitiesRepository_ = null;

        public EntityMashService(IEntitiesRepository entitiesRepository)
        {
            entitiesRepository_ = entitiesRepository;
        }

        /// <summary>
        /// Implementation of <see cref="IEntityMashService.GetRanking"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entity> GetRanking()
        {
            return entitiesRepository_.Entities.OrderByDescending(c => c.Votes);
        }

        /// <summary>
        /// Implementation of <see cref="IEntityMashService.GetVersus"/>
        /// </summary>
        /// <returns></returns>
        public Tuple<Entity, Entity> GetVersus()
        {
            if (entitiesRepository_.Entities.Count() < 2)
                throw new ApplicationException("Can't get a versus if there is only one entity.");
            Entity entity1 = GetARandomEntity();
            Entity entity2 = GetARandomEntity();
            while (entity1.Identifier == entity2.Identifier)
            {
                entity1 = GetARandomEntity();
                entity2 = GetARandomEntity();
            }

            return new Tuple<Entity, Entity>(entity1, entity2);
        }

        /// <summary>
        /// Implementation of <see cref="IEntityMashService.AddVote(Entity)"/>
        /// </summary>
        /// <param name="entity"></param>
        public void AddVote(string identifier)
        {
            var entity = entitiesRepository_.Entities.SingleOrDefault(e => e.Identifier == identifier);
            entity.Votes++;
            entitiesRepository_.Update(entity);
        }

        /// <summary>
        /// This private method retrieve an entity randomly.
        /// </summary>
        /// <returns></returns>
        private Entity GetARandomEntity()
        {
            var random = new Random();
            var index = random.Next(entitiesRepository_.Entities.Count() - 1);
            return entitiesRepository_.Entities.ElementAt(index);
        }
    }
}
