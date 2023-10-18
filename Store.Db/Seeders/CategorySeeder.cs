using Microsoft.EntityFrameworkCore;
using Store.Db.Entities;

namespace Store.Db.Seeders
{
    internal class CategorySeeder : ISeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category { Id = 1, Name = "Lacteos", Description = ""},
                new Category { Id = 2, Name = "Cereales", Description = ""},
                new Category { Id = 3, Name = "Menestras", Description = ""},
                new Category { Id = 4, Name = "Embutidos", Description = ""},
                new Category { Id = 5, Name = "Bebidas", Description = ""},
                new Category { Id = 6, Name = "Bebidas Alcoholicas", Description = ""},
            });

            modelBuilder.Entity<Brand>().HasData(new[]
            {
                new Brand { Id = 1, Name = "GLORIA", Description = ""},
                new Brand { Id = 2, Name = "VOLT", Description = ""},
                new Brand { Id = 3, Name = "SUBLIME", Description = ""},
                new Brand { Id = 4, Name = "INKA COLA", Description = ""},
                new Brand { Id = 5, Name = "DON VICTORIO", Description = ""},
                new Brand { Id = 6, Name = "ALTOMAYO", Description = ""},
            });
        }
    }
}
