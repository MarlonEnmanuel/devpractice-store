using Store.Core.Modules.Categories.Dtos;

namespace Store.Core.Modules.Categories.Interfaces
{
    public interface ICategoryService
    {
        IList<CategoryDto> Get();

        void Save(SaveCategoryDto dto);

        void Update(int id, SaveCategoryDto dto);

        void Delete(int id);
    }
}
