using System.Data.Entity;
using OliveApp.Legacy.Models;

namespace OliveApp.Legacy.Data
{
    // Classic EF6 DbContext - a hallmark data-access pattern AWS Transform
    // for .NET recognizes and produces a migration path for during
    // assessment (typically toward EF Core / async, cross-platform APIs).
    public class OliveLegacyDbContext : DbContext
    {
        public OliveLegacyDbContext() : base("name=OliveLegacyDbContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            base.OnModelCreating(modelBuilder);
        }
    }
}
