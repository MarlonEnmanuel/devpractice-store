﻿using Microsoft.AspNetCore.Mvc;
using Store.Db;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("category")]
    public class CatagoryController : ControllerBase
    {
        private StoreDBContext _context;

        public CatagoryController(StoreDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("create")]
        public void CrearCategories()
        {
            if (_context.Categories.FirstOrDefault(c => c.Name == "Mascotas") == null)
            {
                _context.Categories.Add(new Category()
                {
                    Name = "Mascotas",
                    Description = "Comida o articulos para mascotas",
                });
            }
            _context.Categories.Add(new Category()
            {
                Name = "Lacteos",
                Description = "Leche queso etc",
            });
            _context.Categories.Add(new Category()
            {
                Name = "Embutidos",
                Description = "",
            });
            _context.SaveChanges();
        }

        [HttpGet]
        public List<Category> GetCatgories()
        {
            return _context.Categories.ToList();
        }


        [HttpPost]
        public void PostCategories(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }


    }
}
