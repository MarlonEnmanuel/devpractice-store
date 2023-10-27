using Microsoft.EntityFrameworkCore;
using Store.Core.Modules.Products.Dtos;
using Store.Core.Modules.Products.Interfaces;
using Store.Core.Modules.Shared.Interfaces;
using Store.Db;
using Store.Db.Entities;

namespace Store.Core.Modules.Products
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;
        private readonly IDtoService _dtoService;

        public ProductService(StoreDbContext context, IDtoService dtoService)
        {
            _context = context;
            _dtoService = dtoService;
        }

        public IList<ProductDto> GetProducts()
        {
            var list = _context.Products.Include(p => p.Categories)
                                        .Include(p => p.Brand).ToList();

            return _dtoService.Map<IList<ProductDto>>(list);
        }

        public void Save(SaveProductDto dto)
        {
            _dtoService.Validate(dto);

            var product = _dtoService.Map<Product>(dto);
            product.Categories = _context.Categories.Where(c => dto.CategoryIds.Contains(c.Id)).ToList();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, SaveProductDto productDto)
        {
            _dtoService.Validate(productDto);

            var currentProduct = _context.Products.Find(id);

            if (currentProduct != null && currentProduct.Id == productDto.Id)
            {
                _dtoService.Map(productDto, currentProduct);

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentProduct = _context.Products.Find(id);

            if (currentProduct != null)
            {
                _context.Remove(currentProduct);
                _context.SaveChanges();
            }
        }
    }
}
