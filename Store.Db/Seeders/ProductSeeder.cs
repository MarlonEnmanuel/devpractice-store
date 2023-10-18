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
                new Product { Id = 1,Name="Gloria",Description="leche",Price=10,BrandId=1,Stock=10 }

            });

          
        }
    }
}
