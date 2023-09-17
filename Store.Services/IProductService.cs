using Store.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IProductService
    {
        IList<Product> Get();

        void Save(Product product);

        void Update(int id, Product product);

        void Delete(int id);
    }
}
