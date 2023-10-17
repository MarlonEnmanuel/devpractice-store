using AutoMapper;
using Store.Core.Modules.Products.Dtos;
using Store.Db.Entities;

namespace Store.Core.Modules.Products
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
