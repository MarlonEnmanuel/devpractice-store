using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Store.Db
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
