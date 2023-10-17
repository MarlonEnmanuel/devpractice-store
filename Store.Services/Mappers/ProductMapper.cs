using AutoMapper;
using Store.Core.Dtos;
using Store.Db.Entities;

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
