using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using Store.Core.Modules.Shared;
using Store.Db;
using System.Reflection;

namespace Store.Test.Store.Core
{
    public static class MockHelper
    {
        public static readonly IMapper MapperInstance = LoadMappers();

        public static readonly IServiceProvider ValidatorServices = LoadValidators();

        public static Mock<DtoService> GetDtoServiceMock()
        {
            var dtoServiceMock = new Mock<DtoService>(MapperInstance, ValidatorServices);

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
            contextMock.Setup(c => c.Categories).ReturnsDbSet(fakeDb.Categories);
            contextMock.Setup(c => c.Products).ReturnsDbSet(fakeDb.Products);
            contextMock.Setup(c => c.Suppliers).ReturnsDbSet(fakeDb.Suppliers);
            contextMock.Setup(c => c.Brands).ReturnsDbSet(fakeDb.Brands);

            return contextMock;
        }

        private static IMapper LoadMappers()
        {
            var configurarion = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.Load("Store.Core"));
            });
            return configurarion.CreateMapper();
        }

        private static IServiceProvider LoadValidators()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddValidatorsFromAssembly(Assembly.Load("Store.Core"));
            return serviceCollection.BuildServiceProvider();
        }

        private static IReturnsResult<TMock> ReturnsDbSet<TMock, TEntity>(this IReturns<TMock, DbSet<TEntity>> setup, List<TEntity> sourceList)
            where TMock : class
            where TEntity : class
        {
            var dbSetMock = new Mock<DbSet<TEntity>>();

            // Mock para consultas
            var queryable = sourceList.AsQueryable();
            dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            // Mock para Add
            dbSetMock.Setup(d => d.Add(It.IsAny<TEntity>()))
                     .Callback<TEntity>(sourceList.Add);

            // Mock para AddRange
            dbSetMock.Setup(d => d.AddRange(It.IsAny<IEnumerable<TEntity>>()))
                     .Callback<IEnumerable<TEntity>>(entities => sourceList.AddRange(entities));

            // Mock para Remove
            dbSetMock.Setup(d => d.Remove(It.IsAny<TEntity>()))
                     .Callback<TEntity>(entity => sourceList.Remove(entity));

            // Mock para RemoveRange
            dbSetMock.Setup(d => d.RemoveRange(It.IsAny<IEnumerable<TEntity>>()))
                     .Callback<IEnumerable<TEntity>>(entities =>
                     {
                         foreach (var entity in entities)
                         {
                             sourceList.Remove(entity);
                         }
                     });

            return setup.Returns(dbSetMock.Object);
        }
    }
}
