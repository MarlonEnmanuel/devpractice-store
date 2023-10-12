using Microsoft.AspNetCore.Mvc;
using Store.Services;
using Store.Services.Dtos;
using FluentValidation;
using FluentValidation.Results;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
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
            return Ok(_productService.GetProducts());
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
