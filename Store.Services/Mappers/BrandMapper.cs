using AutoMapper;
using Store.Db;
using Store.Core.Dtos;

namespace Store.Core.Mappers
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
