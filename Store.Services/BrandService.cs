using AutoMapper;
using FluentValidation;
using Store.Db;
using Store.Services.Dtos;

namespace Store.Services
{
    public class BrandService : IBrandService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SaveBrandDto> _validator;

        public BrandService(StoreDBContext context, IMapper mapper, IValidator<SaveBrandDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public IList<BrandDto> GetBrandList()
        {
            var list = _context.Brands.ToList();
            return _mapper.Map<IList<BrandDto>>(list);
        }

        public void SaveBrand(SaveBrandDto dto)
        {
            _validator.ValidateAndThrow(dto);
            
            var brand = _mapper.Map<Brand>(dto);
            
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void UpdateBrand(int id, SaveBrandDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return;
            }

            _validator.ValidateAndThrow(dto);

            var currentBrand = _context.Brands.Find(id);
            if (currentBrand == null)
            {
                return;
            }

            _mapper.Map(dto, currentBrand);
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

    public interface IBrandService
    {
        IList<BrandDto> GetBrandList();

        void SaveBrand(SaveBrandDto dto);

        void UpdateBrand(int id, SaveBrandDto dto);

        void DeleteBrand(int id);
    }
}

