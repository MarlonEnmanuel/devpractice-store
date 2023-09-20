using Store.Db;

namespace Store.Services.Interface
{
    public interface ISupplierService
    {
        IList<Supplier> Get();

        Supplier GetById(int idSupplier);

        void Save(Supplier supplier);

        void Update(int idSupplier, Supplier supplier);

        void Delete(int idSupplier);
    }
}
