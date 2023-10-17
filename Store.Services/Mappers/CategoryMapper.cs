using AutoMapper;
using Store.Db;
using Store.Core.Dtos;

namespace Store.Core.Mappers
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
