using AutoMapper;
using Store.Core.Modules.Categories;
using Store.Core.Modules.Products;
using Store.Core.Modules.Products.Dtos;
using Store.Db.Entities;

namespace Store.Test.Store.Core.Products
{
    public class ProductMapperTest
    {
        private readonly IMapper _mapper;

        public ProductMapperTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>();
                cfg.AddProfile<CategoryMapper>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Map_Product_to_ProductDto()
        {
            var entity = new Product
            {
                Id = 1,
                Name = "Gloria",
                Description = "leche",
                Price = 10,
                BrandId = 1,
                Stock = 20,
                Categories = new List<Category>
                {
                    new Category { Id = 1 , Name = "Lacteos" , Description = ""},
                    new Category { Id = 2 , Name = "Cereales" , Description = ""}
                },
                Brand = new Brand { Name = "GLORIA" }

            };

            var dto = _mapper.Map<ProductDto>(entity);

            Assert.Equal(1, dto.Id);
            Assert.Equal("Gloria", dto.Name);
            Assert.Equal("leche", dto.Description);
            Assert.Equal(10, dto.Price);
            Assert.Equal(1, dto.BrandId);
            Assert.Equal(20, dto.Stock);
            Assert.Equal(2, dto.Categories?.Count);
            Assert.Equal("GLORIA", dto.BrandName);
        }
    }
}
