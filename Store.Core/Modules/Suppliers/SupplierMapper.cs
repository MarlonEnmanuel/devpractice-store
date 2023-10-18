using AutoMapper;
using Store.Core.Modules.Suppliers.Dtos;
using Store.Db.Entities;

namespace Store.Core.Modules.Suppliers
{
    public class SupplierMapper : Profile
    {
        public SupplierMapper()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SaveSupplierDto, Supplier>();
        }
    }
}
