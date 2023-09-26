using Microsoft.AspNetCore.Mvc;
using Store.Db;
using Store.Services;
using Store.Services.Dtos;

namespace Store.Api.Controllers
{
    
        [ApiController]
        [Route("api/product")]
        public class ProductController : Controller
        {
            private readonly IProductService _productService;

            public ProductController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_productService.Get());
            }

            [HttpPost]
            public IActionResult Post([FromBody] SaveProductDto dto)
            {
                _productService.Save(dto);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] SaveProductDto product)
            {
                _productService.Update(id, product);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _productService.Delete(id);
                return Ok();
            }

        }
}
