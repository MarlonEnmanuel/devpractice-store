using AutoMapper;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services.Mappers
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
