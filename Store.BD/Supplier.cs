

namespace Store.Db
{
    public class Supplier
    {
        public int Id { get; set; }
        public string RucSupplier { get; set; }
        public string BusinessName { get; set; }
        public virtual ICollection<Product>? Products{ get; set; }

    }
}
