using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Store.Core.Modules.Shared;
using Store.Core.Modules.Shared.Interfaces;
using Store.Db;
using Store.Test.Store.DB;
using System.Reflection;

namespace Store.Test.Store.Core
{
    public abstract class BaseTest
    {
        protected static readonly IDtoService _dtoService;

        protected readonly StoreDbContextMock _contextMock;

        protected readonly StoreDbContext _context;

        static BaseTest()
        {
            _dtoService = new DtoService(GetMapper(), GetValidators());
        }

        protected BaseTest()
        {
            _contextMock = new StoreDbContextMock();
            _context = _contextMock.ContextMock.Object;
        }

        private static IMapper GetMapper()
        {
            var configurarion = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.Load("Store.Core"));
            });
            return configurarion.CreateMapper();
        }

        private static IServiceProvider GetValidators()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddValidatorsFromAssembly(Assembly.Load("Store.Core"));
            return serviceCollection.BuildServiceProvider();
        }
    }
}
