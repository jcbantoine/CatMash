using System;
using EntityMash.Database.Models;
using EntityMash.Models;

namespace EntityMash.Database.Mapping
{
    public static class ModelsExtensions
    {
        public static DBEntity ToDBModel(this Entity entity)
        {
            return new DBEntity { Identifier = entity.Identifier, ImageUrl = entity.ImageUrl.ToString(), Votes = entity.Votes };
        }

        public static Entity ToModel(this DBEntity entityDb)
        {
            return new Entity(entityDb.Identifier) { ImageUrl = new Uri(entityDb.ImageUrl), Votes = entityDb.Votes };
        }
    }
}
