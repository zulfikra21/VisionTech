using Microsoft.EntityFrameworkCore;
using VisionTech.Api.Domain.Entities;

namespace VisionTech.Api.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed some data if needed or configure entities
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Laptop", Description = "High-end gaming laptop", Price = 1500, Stock = 10, CreatedAt = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Mouse", Description = "Wireless gaming mouse", Price = 50, Stock = 100, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
