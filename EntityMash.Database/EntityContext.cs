using Microsoft.EntityFrameworkCore;
using EntityMash.Database.Models;

namespace EntityMash.Database
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public DbSet<EntityDB> Entities { get; set; }
    }

}
