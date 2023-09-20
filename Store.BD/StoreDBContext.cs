using Microsoft.EntityFrameworkCore;

namespace Store.Db
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(Category =>
            {
                Category.ToTable("Category");
                Category.HasKey(p => p.Id);

                Category.Property(p => p.Name).IsRequired().HasMaxLength(30);
                Category.Property(p => p.Description).IsRequired(false).HasMaxLength(100);
            });
            modelBuilder.Entity<Supplier>(Supplier =>
            {
                Supplier.ToTable("Supplier");
                Supplier.HasKey(p => p.Id);

                Supplier.Property(p => p.RucSupplier).IsRequired().HasMaxLength(11);
                Supplier.Property(p => p.BusinessName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
