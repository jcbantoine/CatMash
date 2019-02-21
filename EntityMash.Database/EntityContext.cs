using Microsoft.EntityFrameworkCore;

using EntityMash.Database.Models;

namespace EntityMash.Database
{
    public class EntityContext : DbContext
    {
        private readonly string connectionString_;

        public EntityContext(string connectionString)
        {
            connectionString_ = connectionString;
        }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public DbSet<DBEntity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connectionString_))
                optionsBuilder.UseSqlServer(connectionString_);
        }

    }

}
