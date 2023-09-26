using AutoMapper;
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
            var list = _context.Products.ToList();
            return _mapper.Map<IList<ProductDto>>(list); 
        }

        public void Save(SaveProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
           

                _context.Products.Add(product);
                _context.SaveChanges();
            
        }

        public void Update(int id, SaveProductDto product)
        {

            var ProductNow = _context.Products.Find(id);

            if (ProductNow != null && ProductNow.Id == product.Id)
            {
                ProductNow.Name = product.Name;
                ProductNow.Description = product.Description;
                ProductNow.Price = product.Price;
                ProductNow.Stock = product.Stock;
               ProductNow.expirationDate = product.expirationDate;


                _context.SaveChanges();
            }
          
        }

        public void Delete(int id)
        {
       

            var productNow = _context.Products.Find(id);

            if (productNow != null)
            {
                _context.Remove(productNow);
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
