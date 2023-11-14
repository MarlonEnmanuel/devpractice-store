using AutoMapper;
using Store.Core.Modules.Brands.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Brands
{
    public class BrandMapperTest
    {
        private readonly IMapper _mapper = MockHelper.MapperInstance;

        [Fact]
        public void Map_Brand_to_BrandDto()
        {
            var entity = new Brand
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
            };

            var dto = _mapper.Map<BrandDto>(entity);

            Assert.Equal(1, dto.Id);
            Assert.Equal("TestName", dto.Name);
            Assert.Equal("TestDescription", dto.Description);
        }
    }
}
