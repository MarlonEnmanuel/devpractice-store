using Microsoft.EntityFrameworkCore;
using Store.Db.Entities;

namespace Store.Db.Seeders
{
    internal class BrandSeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(new[]
            {
                new Brand { Id = 1, Name = "GLORIA", Description = ""},
                new Brand { Id = 2, Name = "VOLT", Description = ""},
                new Brand { Id = 3, Name = "SUBLIME", Description = "" },
                new Brand { Id = 4, Name = "INKA COLA", Description = "" },
                new Brand { Id = 5, Name = "DON VICTORIO", Description = "" },
                new Brand { Id = 6, Name = "ALTOMAYO", Description = "" },
            });
        }

    }
}
