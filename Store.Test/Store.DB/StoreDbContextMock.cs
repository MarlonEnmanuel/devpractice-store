using Moq;
using Moq.EntityFrameworkCore;
using Store.Db;
using Store.Db.Entities;

namespace Store.Test.Store.DB
{
    public class StoreDbContextMock
    {
        public readonly Mock<StoreDbContext> ContextMock;

        public readonly List<Category> Categories = new();
        public readonly List<Product> Products = new();
        public readonly List<Supplier> Suppliers = new();
        public readonly List<Brand> Brands = new();

        public StoreDbContextMock()
        {
            // Mock del contexto
            ContextMock = new Mock<StoreDbContext>();
            ContextMock.Setup(c => c.SaveChanges())
                       .Returns(1);
            ContextMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                       .Returns<CancellationToken>(_ => Task.FromResult(1));

            // Mocks de los DbSet
            ContextMock.Setup(c => c.Categories).ReturnsDbSet(Categories);
            ContextMock.Setup(c => c.Products).ReturnsDbSet(Products);
            ContextMock.Setup(c => c.Suppliers).ReturnsDbSet(Suppliers);
            ContextMock.Setup(c => c.Brands).ReturnsDbSet(Brands);
        }
    }
}
