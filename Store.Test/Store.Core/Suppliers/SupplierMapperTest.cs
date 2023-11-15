using AutoMapper;
using Store.Core.Modules.Suppliers.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Suppliers
{
    public class SupplierMapperTest
    {
        private readonly IMapper _mapper = MockHelper.MapperInstance;

        [Fact]
        public void Map_Supplier_to_SupplierDto()
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

        [Fact]
        public void Map_SaveSupplierDto_for_create()
        {
            var dto = new SaveSupplierDto
            {
                RucSupplier = "10475214581",
                BusinessName = "Inversiones Create SA.",
            };

            var entity = _mapper.Map<Supplier>(dto);

            Assert.Equal(entity.Id, 0);
            Assert.Equal(dto.RucSupplier, entity.RucSupplier);
            Assert.Equal(dto.BusinessName, entity.BusinessName);
        }

        [Fact]
        public void Map_SaveSupplierDto_for_update()
        {
            var dto = new SaveSupplierDto
            {
                Id = 1,
                RucSupplier = "20476531382",
                BusinessName = "Inversiones Update SA.",
            };

            var entity = _mapper.Map<Supplier>(dto);

            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.RucSupplier, entity.RucSupplier);
            Assert.Equal(dto.BusinessName, entity.BusinessName);
        }
    }
}
