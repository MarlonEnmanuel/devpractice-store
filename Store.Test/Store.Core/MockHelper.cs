using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Moq.Language.Flow;
using Store.Core.Modules.Shared;
using Store.Db;

namespace Store.Test.Store.Core
{
    public static class MockHelper
    {
        public static readonly IMapper MapperInstance;

        static MockHelper()
        {
            var configurarion = new MapperConfiguration(cfg => {
                cfg.AddMaps("Store.Core");
            });
            MapperInstance = configurarion.CreateMapper();
        }

        public static Mock<DtoService> GetDtoServiceMock()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            var dtoServiceMock = new Mock<DtoService>(MapperInstance, serviceProviderMock.Object);

            // Mock de Validate (para no validar)
            dtoServiceMock.Setup(s => s.Validate(It.IsAny<object>()))
                          .Callback(() => { });

            // Mock de ValidateAsync (para no validar)
            dtoServiceMock.Setup(s => s.ValidateAsync(It.IsAny<object>()))
                          .Returns(() => Task.CompletedTask);

            return dtoServiceMock;
        }

        public static Mock<StoreDbContext> GetStoreDbContextMock(FakeStoreDb fakeDb)
        {
            var contextMock = new Mock<StoreDbContext>();

            // Mock de SaveChanges y SaveChangesAsync
            contextMock.Setup(c => c.SaveChanges()).Returns(1);
            contextMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                       .Returns((CancellationToken token) => Task.FromResult(1));

            // Mock de los DBSets
            contextMock.Setup(c => c.Categories).MockDbSet(fakeDb.Categories, c => c.Id);
            contextMock.Setup(c => c.Products).MockDbSet(fakeDb.Products, p => p.Id);
            contextMock.Setup(c => c.Suppliers).MockDbSet(fakeDb.Suppliers, s => s.Id);
            contextMock.Setup(c => c.Brands).MockDbSet(fakeDb.Brands, b => b.Id);

            return contextMock;
        }

        public static IReturnsResult<TMock> MockDbSet<TMock, TEntity>(
            this ISetup<TMock, DbSet<TEntity>> setup,
            List<TEntity> sourceList,
            Func<TEntity, object> identifierSelector
        )
            where TMock : class
            where TEntity : class
        {
            TEntity? find(object[] ids)
            {
                if (ids == null || ids.Length == 0) return null;
                object identifier = ids.Length == 1 ? ids[0] : string.Join(string.Empty, ids);
                return sourceList.FirstOrDefault(e => identifierSelector(e).Equals(identifier));
            }

            var mock = new Mock<DbSet<TEntity>>();

            // Mock para Add
            mock.Setup(d => d.Add(It.IsAny<TEntity>()))
                .Callback<TEntity>(entity => sourceList.Add(entity));

            // Mock para AddRange
            mock.Setup(d => d.AddRange(It.IsAny<IEnumerable<TEntity>>()))
                .Callback<IEnumerable<TEntity>>(entities => sourceList.AddRange(entities));

            // Mock para Remove
            mock.Setup(d => d.Remove(It.IsAny<TEntity>()))
                .Callback<TEntity>(entity => sourceList.Remove(entity));

            // Mock para RemoveRange
            mock.Setup(d => d.RemoveRange(It.IsAny<IEnumerable<TEntity>>()))
                .Callback<IEnumerable<TEntity>>(entities => { foreach (var e in entities) sourceList.Remove(e); });

            // Mock para Find
            mock.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => find(ids));

            // Mock para FindAsync
            mock.Setup(m => m.FindAsync(It.IsAny<object[]>()))
                .Returns<object[]>(ids => ValueTask.FromResult(find(ids)));

            // Mock para consultas
            return setup.ReturnsDbSet(sourceList, mock);
        }
    }
}
