using AutoMapper;
using FluentValidation;
using Store.Db;
using Store.Core.Dtos;
using Store.Db.Entities;

namespace Store.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SaveCategoryDto> _validator;

        public CategoryService(StoreDbContext context, IMapper mapper, IValidator<SaveCategoryDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public IList<CategoryDto> Get()
        {
            var list = _context.Categories.ToList();
            return _mapper.Map<IList<CategoryDto>>(list);
        }

        public void Save(SaveCategoryDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var category = _mapper.Map<Category>(dto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            
        }

        public void Update(int id, SaveCategoryDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var currentCategory = _context.Categories.Find(id);

            if (currentCategory != null && currentCategory.Id == dto.Id)
            {
                _mapper.Map(dto, currentCategory);

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
    
    public interface ICategoryService
    {
        IList<CategoryDto> Get();

        void Save(SaveCategoryDto dto);

        void Update(int id, SaveCategoryDto dto);

        void Delete(int id);
    }
}
