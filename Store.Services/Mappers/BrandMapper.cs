using AutoMapper;
using Store.Core.Dtos;
using Store.Db.Entities;

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
