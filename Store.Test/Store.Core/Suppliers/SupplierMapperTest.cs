using AutoMapper;
using Store.Core.Modules.Brands.Dtos;
using Store.Core.Modules.Suppliers;
using Store.Core.Modules.Suppliers.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Suppliers
{
    public class SupplierMapperTest
    {
        private readonly IMapper _mapper;

        public SupplierMapperTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<SupplierMapper>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_Supplier_to_SaveSupplierDto()
        {
            var entity = new Supplier
            {
                Id = 1,
                RucSupplier = "10475214581",
                BusinessName = "Inversiones SA.",
            };

            var dto = _mapper.Map<SupplierDto>(entity);

            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.RucSupplier, dto.RucSupplier);
            Assert.Equal(entity.BusinessName, dto.BusinessName);
        }
    }
}
