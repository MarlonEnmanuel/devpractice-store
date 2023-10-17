using Store.Core.Modules.Brands.Dtos;

namespace Store.Core.Modules.Brands.Interfaces
{
    public interface IBrandService
    {
        IList<BrandDto> GetBrandList();

        void SaveBrand(SaveBrandDto dto);

        void UpdateBrand(int id, SaveBrandDto dto);

        void DeleteBrand(int id);
    }
}
