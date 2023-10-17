using Store.Core.Modules.Suppliers.Dtos;

namespace Store.Core.Modules.Suppliers.Interfaces
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
