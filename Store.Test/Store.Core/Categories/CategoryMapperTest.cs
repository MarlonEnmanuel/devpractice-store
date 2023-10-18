using AutoMapper;
using Store.Core.Modules.Categories;
using Store.Core.Modules.Categories.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Categories
{
    public class CategoryMapperTest
    {
        private readonly IMapper _mapper;

        public CategoryMapperTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CategoryMapper>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_Category_to_CategoryDto()
        {
            var entity = new Category
            {
                Id = 1,
                Name = "TestCategory",
                Description = "TestCategoryDescription",
            };

            var dto = _mapper.Map<CategoryDto>(entity);

            Assert.Equal(1, dto.Id);
            Assert.Equal("TestCategory", dto.Name);
            Assert.Equal("TestCategoryDescription", dto.Description);
        }
    }
}
