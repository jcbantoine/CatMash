using EntityMash.Database;
using EntityMash.Database.Mapping;
using EntityMash.Models;
using EntityMash.Services.Interop;
using System.Collections.Generic;
using System.Linq;

namespace EntityMash.Services
{
    public class EntitiesDBRepository : IEntitiesRepository
    {
        private readonly EntityContext context_;

        public EntitiesDBRepository(EntityContext context)
        {
            context_ = context;
        }

        public IEnumerable<Entity> Entities => context_.Entities.Select(e=>e.ToModel());

        public void Update(Entity entity)
        {
            context_.Entities.Update(entity.ToDBModel());
            context_.SaveChanges();
        }
    }
}
