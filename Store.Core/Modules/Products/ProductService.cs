using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Store.Core.Modules.Products.Dtos;
using Store.Core.Modules.Products.Interfaces;
using Store.Db;
using Store.Db.Entities;

namespace Store.Core.Modules.Products
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SaveProductDto> _validator;

        public ProductService(StoreDbContext context, IMapper mapper, IValidator<SaveProductDto> validator)
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
            _validator.ValidateAndThrow(productDto);

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
}
