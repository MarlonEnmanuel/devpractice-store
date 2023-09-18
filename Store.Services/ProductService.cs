using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Store.Services
{
    public class ProductService: IProductService
    {
        private readonly StoreDBContext _context;

        public ProductService(StoreDBContext context)
        {
            _context = context;
        }

        public IList<Product> GetList()
        {
            return _context.Products.Include(p => p.Categories)
                                    .ToList();
        }

        public void Save(Product product)
        {
            var products = _context.Products.Find(product.Id);
            if (products == null)
            {
                var categoryIds = product.Categories?.Select(c => c.Id).ToArray();
                var categoryList = _context.Categories.Where(c=> categoryIds.Contains(c.Id)).ToList();
                product.Categories = categoryList;

                _context.Add(product);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Remove(product);

                _context.SaveChanges();
            }

        }
    }

    public interface IProductService
    {
        IList<Product> GetList();

        void Save(Product product);

        void Update(int id, Product product);

        void Delete(int id);
    }
}
