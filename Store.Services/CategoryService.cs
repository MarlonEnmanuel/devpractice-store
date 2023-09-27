﻿using AutoMapper;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;

        public CategoryService(StoreDBContext dbcontext, IMapper mapper)
        {
            _context = dbcontext;
            _mapper = mapper;
        }

        public IList<CategoryDto> Get()
        {
            var list = _context.Categories.ToList();
            return _mapper.Map<IList<CategoryDto>>(list);
        }

        public void Save(SaveCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var CategoryNow = _context.Categories.Find(id);

            if (CategoryNow != null && CategoryNow.Id == category.Id)
            {
                CategoryNow.Name = category.Name;
                CategoryNow.Description = category.Description;

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

        void Save(SaveCategoryDto category);

        void Update(int id, Category category);

        void Delete(int id);
    }
}
