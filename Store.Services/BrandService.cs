using Store.Db;

namespace Store.Services
{
    public class BrandService : IBrandService
    {
        private readonly StoreDBContext _context;

        public BrandService(StoreDBContext dbcontext)
        {
            _context = dbcontext;
        }

        public IList<Brand> Get()
        {
            return _context.Brands.ToList();
        }

        public void Save(Brand brand)
        {
            _context.Add(brand);
            _context.SaveChanges();
        }

        public void Update(int id, Brand brand)
        {
            var BrandNow = _context.Brands.Find(id);

            if (BrandNow != null && BrandNow.Id == brand.Id)
            {
                BrandNow.Name = brand.Name;
                BrandNow.Description = brand.Description;

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
        IList<Brand> Get();

        void Save(Brand brand);

        void Update(int id, Brand brand);

        void Delete(int id);
    }
}

