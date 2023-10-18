using Microsoft.EntityFrameworkCore;
using Store.Db.Entities;
using Store.Db.Seeders;

namespace Store.Db
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(Category =>
            {
                Category.Property(p => p.Name).IsRequired().HasMaxLength(30);
                Category.Property(p => p.Description).IsRequired(false).HasMaxLength(100);
            });

            modelBuilder.Entity<Supplier>(Supplier =>
            {
                Supplier.Property(p => p.RucSupplier).IsRequired().HasMaxLength(11);
                Supplier.Property(p => p.BusinessName).IsRequired().HasMaxLength(100);

            });

            modelBuilder.Entity<Brand>(Brand =>
            {
                Brand.Property(p => p.Name).IsRequired().HasMaxLength(30);
                Brand.Property(p => p.Description).IsRequired(false).HasMaxLength(100);
            });

            new CategorySeeder().Seed(modelBuilder);
            new SupplierSeeder().Seed(modelBuilder);
            new BrandSeeder().Seed(modelBuilder);
        }
    }
}
