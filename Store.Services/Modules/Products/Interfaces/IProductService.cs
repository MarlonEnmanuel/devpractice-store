using Store.Core.Modules.Products.Dtos;

namespace Store.Core.Modules.Products.Interfaces
{
    public interface IProductService
    {
        IList<ProductDto> GetProducts();

        void Save(SaveProductDto productDto);

        void Update(int id, SaveProductDto productDto);

        void Delete(int id);
    }
}
