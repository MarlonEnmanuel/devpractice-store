using Store.Core.Modules.Brands.Dtos;
using Store.Core.Modules.Brands.Interfaces;
using Store.Core.Modules.Shared.Interfaces;
using Store.Db;
using Store.Db.Entities;

namespace Store.Core.Modules.Brands
{
    public class BrandService : IBrandService
    {
        private readonly StoreDbContext _context;
        private readonly IDtoService _dtoService;

        public BrandService(StoreDbContext context, IDtoService dtoService)
        {
            _context = context;
            _dtoService = dtoService;
        }

        public IList<BrandDto> GetBrandList()
        {
            var list = _context.Brands.ToList();
            return _dtoService.Map<IList<BrandDto>>(list);
        }

        public void SaveBrand(SaveBrandDto dto)
        {
            _dtoService.Validate(dto);

            var brand = _dtoService.Map<Brand>(dto);

            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void UpdateBrand(int id, SaveBrandDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return;
            }

            _dtoService.Validate(dto);

            var currentBrand = _context.Brands.Find(id);
            if (currentBrand == null)
            {
                return;
            }

            _dtoService.Map(dto, currentBrand);
            _context.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var currentBrand = _context.Brands.Find(id);
            if (currentBrand == null)
            {
                return;
            }

            _context.Remove(currentBrand);
            _context.SaveChanges();
        }
    }
}

