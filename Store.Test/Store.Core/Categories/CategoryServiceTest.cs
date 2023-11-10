using Store.Core.Modules.Categories;
using Store.Core.Modules.Categories.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Categories
{
    public class CategoryServiceTest : BaseTest
    {
        public readonly CategoryService _categoryService;

        public CategoryServiceTest() : base()
        {
            _categoryService = new CategoryService(_context, _dtoService);
        }

        //[Fact]
        //public void Save_ShouldSaveCategory()
        //{
        //    var category = new SaveCategoryDto()
        //    {
        //        Id = 1,
        //        Name = "Categoria 1",
        //        Description = "Descripcion 1",
        //    };

        //    _categoryService.Save(category);

        //    Assert.NotEmpty(_contextMock.Categories);
        //    Assert.Single(_contextMock.Categories);
        //    Assert.Equal(1, _contextMock.Categories[0].Id);
        //}

        [Fact]
        public void Get_ShouldGetCategory()
        {
            _contextMock.Categories.Add(new Category { Id = 1, Name = "Categoria 1", Description = "Decripcion 1" });
            _contextMock.Categories.Add(new Category { Id = 2, Name = "Categoria 2", Description = "Decripcion 2" });

            var result = _categoryService.Get();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }
    }
}
