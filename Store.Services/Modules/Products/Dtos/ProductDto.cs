using Store.Core.Modules.Categories.Dtos;

namespace Store.Core.Modules.Products.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public List<CategoryDto>? Categories { get; set; }
    }
}
