namespace Store.Db
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        
        // foreigns
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
