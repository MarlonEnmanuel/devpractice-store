﻿
namespace Store.Services.Dtos
{
    public class SaveProductDto
    {

        public int? Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public DateTime expirationDate { get; set; }
    }
}
