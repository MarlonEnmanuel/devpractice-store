using AutoMapper;
using Store.Db;
using Store.Core.Dtos;

namespace Store.Core.Mappers
{
    internal class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<SaveProductDto, Product>();
        }
    }
}
