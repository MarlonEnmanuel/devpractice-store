using Microsoft.AspNetCore.Mvc;
using Store.Db;
using Store.Services;
using Store.Services.Dtos;

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
        public IActionResult Post([FromBody] SaveBrandDto dto)
        {
            _brandService.Save(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveBrandDto dto)
        {
            _brandService.Update(id, dto);
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
