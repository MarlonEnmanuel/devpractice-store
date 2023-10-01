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
            Supplier oSupplier = GetProviderById(idSupplier);
            if (oSupplier != null)
            {
                _context.Suppliers.Remove(oSupplier);
                _context.SaveChanges();
            }
        }

        public IList<Supplier> Get()
        {
            return _context.Suppliers.Include(p => p.Products).ToList();
        }

        public Supplier GetById(int idSupplier)
        {
            return GetProviderById(idSupplier);
        }

        public void Save(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(int idSupplier, Supplier supplier)
        {
            Supplier oSupplier = GetProviderById(idSupplier);
            if (oSupplier != null)
            {
                _context.Entry(oSupplier).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        private Supplier GetProviderById(int idSupplier)
        {
            return _context.Suppliers.Find(idSupplier);
        }
    }
}
