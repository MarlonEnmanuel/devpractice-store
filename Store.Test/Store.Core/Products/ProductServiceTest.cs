using Store.Core.Modules.Products;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Products
{
    public class ProductServiceTest
    {
        private readonly FakeStoreDb _fakeDb = new();

        private readonly ProductService _productService;

        public ProductServiceTest()
        {
            var dtoServiceMock = MockHelper.GetDtoServiceMock();
            var contextMock = MockHelper.GetStoreDbContextMock(_fakeDb);

            _productService = new ProductService(contextMock.Object, dtoServiceMock.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturnEmpty()
        {
            var result = _productService.GetProducts();
            Assert.Empty(result);
        }

        [Fact]
        public void GetProducts_ShouldReturElements()
        {
            _fakeDb.Products.Add(new() { Id = 1, Name = "producto1" });
            _fakeDb.Products.Add(new() { Id = 2, Name = "producto2" });

            var result = _productService.GetProducts();
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetProducts_ShouldReturWithCategories()
        {
            _fakeDb.Categories.Add(new() { Id = 9, Name = "Cat9" });
            _fakeDb.Products.Add(new() { Id = 1, Name = "Prod1", Categories = new List<Category>() { new() { Id = 9 } } });

            var result = _productService.GetProducts();

            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.NotEmpty(result[0].Categories!);
            Assert.Equal(9, result[0].Categories![0].Id);
        }
    }
}
