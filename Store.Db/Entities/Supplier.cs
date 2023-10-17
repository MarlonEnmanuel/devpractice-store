namespace Store.Db.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string RucSupplier { get; set; }
        public string BusinessName { get; set; }

        // foreigns
        public virtual ICollection<Product>? Products { get; set; }

    }
}
