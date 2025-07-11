using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothes"},
                new Category { Id = 2, Name = "Furniture" },
                new Category { Id = 3, Name = "Kitchen" }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Suit", Description= "Tuxedo for men", Price = 1000, QuantityAvaliable =4, CategoryId = 1},
                new Product {Id = 2, Name = "Microwave", Description = "Kitchen appliance that quickly heats or cooks food", Price = 2000, QuantityAvaliable = 3, CategoryId = 3 },
                new Product{ Id = 3, Name = "Bedroom", Price = 4000, QuantityAvaliable = 5, CategoryId = 2 }

                );

        }
    }
}
