using AutoMapper;
using Store.Core.Modules.Categories.Dtos;
using Store.Db.Entities;

namespace Store.Core.Modules.Categories
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<SaveCategoryDto, Category>();
        }
    }
}
