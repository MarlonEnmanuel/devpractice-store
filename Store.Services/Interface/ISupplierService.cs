using Store.Core.Dtos;

namespace Store.Core.Interface
{
    public interface ISupplierService
    {
        IList<SupplierDto> GetSupplierFindAll();

        SupplierDto GetSupplierById(int idSupplier);

        void SaveSupplier(SaveSupplierDto supplier);

        void UpdateSupplier(int idSupplier, SaveSupplierDto supplier);

        void DeleteSupplier(int idSupplier);
    }
}
