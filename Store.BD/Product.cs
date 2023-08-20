﻿namespace Store.Db
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // foreigns
        public virtual ICollection<Category> Categories { get; set; }
    }
}
