﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Db
{
    public class Brand
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public virtual ICollection<Product>? Products { get; set; }
    }
}
