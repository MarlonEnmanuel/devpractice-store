using Microsoft.EntityFrameworkCore;
using Store.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ProductService: IProductService
    {
        private readonly StoreDBContext _context;

        public ProductService(StoreDBContext context)
        {
            _context = context;
        }

        public IList<Product> Get()
        {
            return _context.Products.ToList();
        }

        public void Save(Product product)
        {
            var products = _context.Products.Find(product.Id);
            if (products == null)
            {
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
            var producto_encontrado = _context.Products.Find(id);
            if (producto_encontrado != null)
            {
                _context.Remove(producto_encontrado);

                _context.SaveChanges();
            }

        }
    }

    public interface IProductService
    {

        IList<Product> Get();

        void Save(Product product);

        void Update(int id, Product product);

        void Delete(int id);
    }
}
