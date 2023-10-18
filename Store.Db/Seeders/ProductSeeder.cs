using Microsoft.EntityFrameworkCore;
using Store.Db.Entities;

namespace Store.Db.Seeders
{
    internal class ProductSeeder : ISeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product { Id = 1, Name = "Gloria", Description = "leche", Price = 10,BrandId = 1, Stock = 10 },
                new Product { Id = 2, Name = "Cereal Angel", Description = "Cereal Angel", Price = 5, BrandId =1, Stock = 10 },
                new Product { Id = 3, Name = "negrita", Description = "negrita", Price = 10, BrandId = 1 , Stock = 10 },
                new Product { Id = 4, Name = "mayor", Description = "mayor", Price = 10, BrandId = 1 , Stock = 10 },
            });
        }
    }
}
