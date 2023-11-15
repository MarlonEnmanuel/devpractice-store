using AutoMapper;
using Store.Core.Modules.Categories.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Categories
{
    public class CategoryMapperTest
    {
        private readonly IMapper _mapper = MockHelper.MapperInstance;

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

            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.Description, dto.Description);
        }

        [Fact]
        public void Map_SaveCategoryDto_for_Create()
        {
            var entity = new SaveCategoryDto
            {
                Name = "TestCategory",
                Description = "TestCategoryDescription",
            };

            var dto = _mapper.Map<Category>(entity);

            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.Description, dto.Description);
        }

        [Fact]
        public void Map_SaveCategoryDto_for_Update()
        {
            var entity = new SaveCategoryDto
            {
                Id = 1,
                Name = "TestCategory",
                Description = "TestCategoryDescription",
            };

            var dto = _mapper.Map<Category>(entity);

            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.Description, dto.Description);
        }
    }
}
