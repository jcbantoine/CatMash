using CatMash.Web.Models;
using EntityMash.Models;

namespace CatMash.Web.Mapping
{
    public static class Mapper
    {
        public static Entity ToModel(CatViewModel cat)
        {
            return new Entity(cat.Identifier) { ImageUrl = cat.ImageUrl, Votes = cat.Votes };
        }

        public static CatViewModel ToViewModel(Entity entity)
        {
            return new CatViewModel { Identifier = entity.Identifier, ImageUrl = entity.ImageUrl, Votes = entity.Votes };
        }
    }
}
