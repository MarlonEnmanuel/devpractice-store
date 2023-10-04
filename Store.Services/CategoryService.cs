using AutoMapper;
using FluentValidation;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SaveCategoryDto> _validator;

        public CategoryService(StoreDBContext context, IMapper mapper, IValidator<SaveCategoryDto> validator)
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

            var CategoryNow = _context.Categories.Find(id);

            if (CategoryNow != null && CategoryNow.Id == dto.Id)
            {
                _mapper.Map(dto, CategoryNow);

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var CategoryNow = _context.Categories.Find(id);

            if (CategoryNow != null)
            {
                _context.Remove(CategoryNow);
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
