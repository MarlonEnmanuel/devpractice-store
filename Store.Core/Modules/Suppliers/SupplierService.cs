using Store.Core.Modules.Shared.Interfaces;
using Store.Core.Modules.Suppliers.Dtos;
using Store.Core.Modules.Suppliers.Interfaces;
using Store.Db;
using Store.Db.Entities;

namespace Store.Core.Modules.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly StoreDbContext _context;
        private readonly IDtoService _dtoService;

        public SupplierService(StoreDbContext context, IDtoService dtoService)
        {
            _context = context;
            _dtoService = dtoService;
        }

        public void DeleteSupplier(int idSupplier)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            if (currentSupplier != null)
            {
                _context.Suppliers.Remove(currentSupplier);
                _context.SaveChanges();
            }
        }

        public IList<SupplierDto> GetSupplierFindAll()
        {
            var supplierList = _context.Suppliers.ToList();
            return _dtoService.Map<IList<SupplierDto>>(supplierList);
        }

        public SupplierDto GetSupplierById(int idSupplier)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            return _dtoService.Map<SupplierDto>(currentSupplier);
        }

        public void SaveSupplier(SaveSupplierDto dto)
        {
            var supplierNow = _dtoService.Map<Supplier>(dto);
            _context.Suppliers.Add(supplierNow);
            _context.SaveChanges();
        }

        public void UpdateSupplier(int idSupplier, SaveSupplierDto dto)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            if (currentSupplier != null && currentSupplier.Id == dto.Id)
            {
                currentSupplier.RucSupplier = dto.RucSupplier;
                currentSupplier.BusinessName = dto.BusinessName;
                _context.SaveChanges();
            }
        }
    }
}
