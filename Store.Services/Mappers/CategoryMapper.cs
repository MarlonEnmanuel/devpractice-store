using AutoMapper;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services.Mappers
{
    internal class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<SaveCategoryDto, Category>();
        }
    }
}
