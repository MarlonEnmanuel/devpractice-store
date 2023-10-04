using Store.Db;
using Store.Services.Dtos;

namespace Store.Services.Interface
{
    public interface ISupplierService
    {
        IList<SupplierDto> Get();

        SupplierDto GetById(int idSupplier);

        void Save(SaveSupplierDto supplier);

        void Update(int idSupplier, SaveSupplierDto supplier);

        void Delete(int idSupplier);
    }
}
