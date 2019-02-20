using System;
using EntityMash.Database.Models;
using EntityMash.Models;

namespace EntityMash.Database
{
    public static class ModelsExtensions
    {
        public static EntityDB ToDBModel(this Entity entity)
        {
            return new EntityDB { Identifier = entity.Identifier, ImageUrl = entity.ImageUrl.ToString(), Votes = entity.Votes };
        }

        public static Entity ToModel(this EntityDB entityDb)
        {
            return new Entity(entityDb.Identifier) { ImageUrl = new Uri(entityDb.ImageUrl), Votes = entityDb.Votes };
        }
    }
}
