using AutoMapper;
using Store.Db;
using Store.Core.Dtos;
namespace Store.Core.Mappers
{
    internal class SupplierMapper :Profile
    {
        public SupplierMapper() {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SaveSupplierDto, Supplier>();
        }
    }
}
