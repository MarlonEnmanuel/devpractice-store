namespace Store.Db
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // foreigns
        public virtual ICollection<Product>? Products { get; set; }
    }
}
