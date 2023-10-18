using Microsoft.EntityFrameworkCore;

namespace Store.Db.Seeders
{
    internal interface ISeeder
    {
        public void Seed(ModelBuilder modelBuilder);
    }
}
