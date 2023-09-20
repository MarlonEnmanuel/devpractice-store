using Microsoft.EntityFrameworkCore;
using Store.Db;
using Store.Services.Interface;

namespace Store.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly StoreDBContext _context;


        public SupplierService(StoreDBContext context)
        {
            _context = context;
        }

        public void Delete(int idSupplier)
        {
            Supplier oSupplier = getProviderById(idSupplier);
            if (oSupplier != null)
            {
                _context.Suppliers.Remove(oSupplier);
                _context.SaveChanges();
            }
        }

        public IList<Supplier> Get()
        {
            return _context.Suppliers.Include(p => p.ProductSupplier).ToList();
        }

        public Supplier GetById(int idSupplier)
        {
            return getProviderById(idSupplier);
        }

        public void Save(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(int idSupplier, Supplier supplier)
        {
            Supplier oSupplier = getProviderById(idSupplier);
            if (oSupplier != null)
            {
                _context.Entry(oSupplier).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        private Supplier getProviderById(int idSupplier)
        {
            var _suplider = _context.Suppliers.Include(p => p.ProductSupplier).ToList()
                 .FirstOrDefault(e => e.Id == idSupplier);
           return _suplider != null ? _suplider : new Supplier();
        }
    }
}
