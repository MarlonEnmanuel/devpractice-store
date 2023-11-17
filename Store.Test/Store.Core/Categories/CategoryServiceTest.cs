using Moq;
using Store.Core.Modules.Categories;
using Store.Core.Modules.Categories.Dtos;
using Store.Core.Modules.Shared;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Categories
{
    public class CategoryServiceTest
    {
        private readonly FakeStoreDb _fakeDb = new();

        public readonly CategoryService _categoryService;

        public readonly Mock<Db.StoreDbContext> _contextMock;

        public readonly Mock<DtoService> _dtoServiceMock;

        public CategoryServiceTest()
        {
            _dtoServiceMock = MockHelper.GetDtoServiceMock();
            _contextMock = MockHelper.GetStoreDbContextMock(_fakeDb);

            _categoryService = new CategoryService(_contextMock.Object, _dtoServiceMock.Object);
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

            _dtoServiceMock.Verify(c => c.Validate(category), Times.Once());
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

            Assert.NotEmpty(_fakeDb.Categories);
            Assert.Single(_fakeDb.Categories);
            Assert.Equal(1, _fakeDb.Categories[0].Id);
            
        }

        [Fact]
        public void Update_ShouldUpdateCategory()
        {
            _fakeDb.Categories.Add(new Category { Id = 1, Name = "Categoria 1", Description = "Decripcion 1" });
            _fakeDb.Categories.Add(new Category { Id = 2, Name = "Categoria 2", Description = "Decripcion 2" });

            var category = new SaveCategoryDto()
            {
                Id = 1,
                Name = "Categoria update 1",
                Description = "Descripcion update 1",
            };

            _categoryService.Update(1, category);

            Assert.Equal("Categoria update 1", _fakeDb.Categories[0].Name);
            Assert.Equal("Descripcion update 1", _fakeDb.Categories[0].Description);

        }

        //[Fact]
        public void Delete_ShouldDeleteCategory()
        {
            _fakeDb.Categories.Add(new Category { Id = 1, Name = "Categoria 1", Description = "Decripcion 1" });
            _fakeDb.Categories.Add(new Category { Id = 2, Name = "Categoria 2", Description = "Decripcion 2" });

            _categoryService.Delete(1);

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
