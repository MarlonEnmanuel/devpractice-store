using AutoMapper;
using Store.Db;
using Store.Services.Dtos;
namespace Store.Services.Mappers
{
    internal class SupplierMapper :Profile
    {
        public SupplierMapper() {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SaveSupplierDto, Supplier>();
        }
    }
}
