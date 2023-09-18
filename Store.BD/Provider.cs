
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Db
{
    public class Provider
    {
        [Key]
        public virtual int Id { get; set; }
        public string RucProvider { get; set; }
        public string BusinessName { get; set; }
        public int CategoryProvider { get; set; }

    }
}
