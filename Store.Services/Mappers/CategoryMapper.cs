using AutoMapper;
using Store.Core.Dtos;
using Store.Db.Entities;

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
