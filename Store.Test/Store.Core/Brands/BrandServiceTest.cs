using Moq;
using Store.Core.Modules.Brands;
using Store.Core.Modules.Brands.Dtos;
using Store.Core.Modules.Shared;
using Store.Db;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Brands
{
    public class BrandServiceTest
    {
        private readonly FakeStoreDb _fakeDb = new();
        private readonly BrandService _brandService;
        private readonly Mock<DtoService> _dtoSeriveMock;
        private readonly Mock<StoreDbContext> _contextMock;

        public BrandServiceTest()
        {
            _dtoSeriveMock = MockHelper.GetDtoServiceMock();
            _contextMock = MockHelper.GetStoreDbContextMock(_fakeDb);
            

            _brandService = new BrandService(_contextMock.Object, _dtoSeriveMock.Object);  
        }

        [Fact]
        public void SaveBrand_ShouldSaveBrand()
        {
            var brand = new SaveBrandDto()
            {
                Id = 1,
                Name = "Brand 1",
                Description = "Description 1",
            };

            _brandService.SaveBrand(brand);

            _dtoSeriveMock.Verify(c => c.Validate(brand), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

            Assert.NotNull(_fakeDb.Brands);
            Assert.NotEmpty(_fakeDb.Brands);
            Assert.Equal(1, _fakeDb.Brands[0].Id);
        }

        [Fact]
        public void GetBrandList_ShouldGetBrand()
        {
            _fakeDb.Brands.Add(new Brand { Id = 1, Name = "Brand 1", Description = "Description 1" });
            _fakeDb.Brands.Add(new Brand { Id = 2, Name = "Brand 2", Description = "Description 2" });

            var result = _brandService.GetBrandList();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void DeleteBrand_ShouldRemoveBrand()
        {
            _fakeDb.Brands.Add(new Brand { Id = 1, Name = "Brand 1", Description = "Description 1" });
            _fakeDb.Brands.Add(new Brand { Id = 2, Name = "Brand 2", Description = "Description 2" });

            _brandService.DeleteBrand(1);

            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

            Assert.Single(_fakeDb.Brands);
            Assert.DoesNotContain(_fakeDb.Brands, b => b.Id == 1);
            Assert.Contains(_fakeDb.Brands, b => b.Id == 2);
        }
    }
}
