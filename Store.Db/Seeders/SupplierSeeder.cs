using Microsoft.EntityFrameworkCore;
using Store.Db.Entities;

namespace Store.Db.Seeders
{
    internal class SupplierSeeder : ISeeder

    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(new[]
            {
                new Supplier{ Id = 1, RucSupplier = "20476531289", BusinessName = "Inversiones Lacteos SA"},
                new Supplier{ Id = 2, RucSupplier = "20317458968", BusinessName = "Inversiones Abarrotes SA"},
                new Supplier{ Id = 3, RucSupplier = "20412552102", BusinessName = "Backus SA"},
                new Supplier{ Id = 4, RucSupplier = "20564120118", BusinessName = "Inversiones Embasados SA"},
            })
                ;
        }
    }
}
