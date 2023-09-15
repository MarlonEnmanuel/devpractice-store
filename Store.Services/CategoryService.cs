using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {

        StoreDBContext _context;

        public CategoryService(StoreDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        public void Save(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var CategoryNow = _context.Categories.Find(id);

            if (CategoryNow != null)
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
        IEnumerable<Category> Get();

        void Save(Category category);

        void Update(int id, Category category);

        void Delete(int id);

    }
}
