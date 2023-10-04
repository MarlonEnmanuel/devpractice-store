using Microsoft.AspNetCore.Mvc;
using Store.Db;
using Store.Services;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brand)
        {
            _brandService = brand;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Brand brand)
        {
            _brandService.Save(brand);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Brand brand)
        {
            _brandService.Update(id, brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.Delete(id);
            return Ok();
        }
    }
}
