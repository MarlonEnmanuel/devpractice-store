using Store.Db.Entities;

namespace Store.Test.Store.Core
{
    public class FakeStoreDb
    {
        public readonly List<Category> Categories = new();
        public readonly List<Product> Products = new();
        public readonly List<Supplier> Suppliers = new();
        public readonly List<Brand> Brands = new();
    }
}
