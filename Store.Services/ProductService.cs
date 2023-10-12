using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using Store.Services.Dtos;
using FluentValidation;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SaveProductDto> _validator;

        public ProductService(StoreDBContext context, IMapper mapper, IValidator<SaveProductDto> validator )
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public IList<ProductDto> GetProducts()
        {
            var list = _context.Products.Include(p => p.Categories)
                                        .Include(p => p.Brand).ToList();

            return _mapper.Map<IList<ProductDto>>(list);
        }

        public void Save(SaveProductDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var product = _mapper.Map<Product>(dto);
            product.Categories = _context.Categories.Where(c => dto.CategoryIds.Contains(c.Id)).ToList();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, SaveProductDto productDto)
        {
            var currentProduct = _context.Products.Find(id);

            if (currentProduct != null && currentProduct.Id == productDto.Id)
            {
                _mapper.Map(productDto, currentProduct);

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

    public interface IProductService
    {
        IList<ProductDto> GetProducts();
        void Save(SaveProductDto productDto);
        void Update(int id, SaveProductDto productDto);
        void Delete(int id);
    }
}
