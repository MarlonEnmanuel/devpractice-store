using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Store.Core.Modules.Shared.Interfaces;

namespace Store.Core.Modules.Shared
{
    public class DtoService : IDtoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public DtoService(IMapper mapper, IServiceProvider serviceProvider)
        {
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination target)
        {
            return _mapper.Map(source, target);
        }

        public virtual void Validate<T>(T instance)
        {
            _serviceProvider.GetRequiredService<IValidator<T>>().ValidateAndThrow(instance);
        }

        public virtual Task ValidateAsync<T>(T instance)
        {
            return _serviceProvider.GetRequiredService<IValidator<T>>().ValidateAndThrowAsync(instance);
        }
    }
}
