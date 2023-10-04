using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services
{
    public class ProductService: IProductService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        public ProductService(StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<ProductDto> Get()
        {
            var list = _context.Products.Include(p=>p.Categories).Include(p=>p.Brand).ToList();
            
            return _mapper.Map<IList<ProductDto>>(list); 
        }

        public void Save(SaveProductDto dto)
        {
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
        IList<ProductDto> Get();
        void Save(SaveProductDto product);
        void Update(int id, SaveProductDto product);
        void Delete(int id);
    }
}
