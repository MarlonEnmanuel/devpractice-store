using AutoMapper;
using Store.Core.Modules.Brands.Dtos;
using Store.Db.Entities;

namespace Store.Core.Modules.Brands
{
    internal class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<SaveBrandDto, Brand>();
        }
    }
}
