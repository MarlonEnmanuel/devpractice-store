using AutoMapper;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services.Mappers
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
