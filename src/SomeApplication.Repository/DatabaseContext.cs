using Microsoft.EntityFrameworkCore;
using SomeApplication.Repository.Mappings;

namespace SomeApplication.Repository
{
    public class DatabaseContext : DbContext
    {
        private const string schema = "public";

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(schema);

            modelBuilder.ApplyConfiguration(new SalesOrderMapping(schema));
            modelBuilder.ApplyConfiguration(new SalesOrderProductMapping(schema));
            modelBuilder.ApplyConfiguration(new PriceMapping(schema));
            modelBuilder.ApplyConfiguration(new ProductMapping(schema));
        }
    }
}
