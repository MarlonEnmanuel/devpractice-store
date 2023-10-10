using AutoMapper;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services
{
    public class BrandService : IBrandService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;

        public BrandService(StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<BrandDto> Get()
        {
            var list = _context.Brands.ToList();
            return _mapper.Map<IList<BrandDto>>(list);
        }
        
        public void Save(SaveBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void Update(int id, SaveBrandDto dto)
        {
            var BrandNow = _context.Brands.Find(id);

            if (BrandNow != null && BrandNow.Id == dto.Id)
            {
                BrandNow.Name = dto.Name;
                BrandNow.Description = dto.Description;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var BrandNow = _context.Brands.Find(id);

            if (BrandNow != null)
            {
                _context.Remove(BrandNow);
                _context.SaveChanges();
            }
        }
    }
    
    public interface IBrandService
    {
        IList<BrandDto> Get();

        void Save(SaveBrandDto dto);

        void Update(int id, SaveBrandDto dto);

        void Delete(int id);
    }
}

