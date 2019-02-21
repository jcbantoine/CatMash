using EntityMash.Database;
using EntityMash.Services;
using System.Linq;

namespace EntityMash.Console.Utils
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length!=2 || (string.IsNullOrEmpty(args[0]) && string.IsNullOrEmpty(args[1])))
            {
                System.Console.WriteLine("An error occured when parsing your command.");
                System.Console.WriteLine("Your command have to respect this format : ");
                System.Console.WriteLine(">.exe [DBConnectionString] [PathToJson]");
            }

            var connectionString = args[0];
            var jsonPath = args[1];
            var dbContext = new EntityContext(connectionString);

            var tempJsonRepo = new EntitiesRuntimeJsonRepository(jsonPath);

            foreach(var entity in tempJsonRepo.Entities)
            {
                if(!dbContext.Entities.Any(e=>e.Identifier == entity.Identifier))
                {
                    dbContext.Entities.Add(entity.ToDBModel());
                }
                dbContext.SaveChanges();
            }
        }
    }
}
