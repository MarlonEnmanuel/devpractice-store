using Store.Core.Modules.Categories;
using Store.Core.Modules.Categories.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Categories
{
    public class CategoryServiceTest
    {
        private readonly FakeStoreDb _fakeDb = new();

        public readonly CategoryService _categoryService;

        public CategoryServiceTest()
        {
            var dtoServiceMock = MockHelper.GetDtoServiceMock();
            var contextMock = MockHelper.GetStoreDbContextMock(_fakeDb);

            _categoryService = new CategoryService(contextMock.Object, dtoServiceMock.Object);
        }

        [Fact]
        public void Save_ShouldSaveCategory()
        {
            var category = new SaveCategoryDto()
            {
                Id = 1,
                Name = "Categoria 1",
                Description = "Descripcion 1",
            };

            _categoryService.Save(category);

            Assert.NotEmpty(_fakeDb.Categories);
            Assert.Single(_fakeDb.Categories);
            Assert.Equal(1, _fakeDb.Categories[0].Id);
        }

        [Fact]
        public void Get_ShouldGetCategory()
        {
            _fakeDb.Categories.Add(new Category { Id = 1, Name = "Categoria 1", Description = "Decripcion 1" });
            _fakeDb.Categories.Add(new Category { Id = 2, Name = "Categoria 2", Description = "Decripcion 2" });

            var result = _categoryService.Get();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }
    }
}
