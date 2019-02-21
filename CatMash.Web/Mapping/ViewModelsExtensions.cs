using CatMash.Web.Models;
using EntityMash.Models;

namespace CatMash.Web.Mapping
{
    public static class ViewModelsExtensions
    {
        public static Entity ToModel(this CatViewModel cat)
        {
            return new Entity(cat.Identifier) { ImageUrl = cat.ImageUrl, Votes = cat.Votes };
        }

        public static CatViewModel ToViewModel(this Entity entity)
        {
            return new CatViewModel { Identifier = entity.Identifier, ImageUrl = entity.ImageUrl, Votes = entity.Votes };
        }
    }
}
