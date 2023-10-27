using Store.Core.Modules.Categories.Dtos;
using Store.Core.Modules.Categories.Interfaces;
using Store.Core.Modules.Shared.Interfaces;
using Store.Db;
using Store.Db.Entities;

namespace Store.Core.Modules.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext _context;
        private readonly IDtoService _dtoService;

        public CategoryService(StoreDbContext context, IDtoService dtoService)
        {
            _context = context;
            _dtoService = dtoService;
        }

        public IList<CategoryDto> Get()
        {
            var list = _context.Categories.ToList();
            return _dtoService.Map<IList<CategoryDto>>(list);
        }

        public void Save(SaveCategoryDto dto)
        {
            _dtoService.Validate(dto);

            var category = _dtoService.Map<Category>(dto);
            _context.Categories.Add(category);
            _context.SaveChanges();

        }

        public void Update(int id, SaveCategoryDto dto)
        {
            _dtoService.Validate(dto);

            var currentCategory = _context.Categories.Find(id);

            if (currentCategory != null && currentCategory.Id == dto.Id)
            {
                _dtoService.Map(dto, currentCategory);

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentCategory = _context.Categories.Find(id);

            if (currentCategory != null)
            {
                _context.Remove(currentCategory);
                _context.SaveChanges();
            }
        }
    }
}
