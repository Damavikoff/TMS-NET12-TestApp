using Microsoft.EntityFrameworkCore;
using NET12_test.Domain.Entities;

namespace NET12_test.Domain
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext() {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=172.20.209.10;Port=5432;Database=test_db;Username=postgres;Password=postgres");
        }
    }
}
