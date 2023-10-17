using Microsoft.AspNetCore.Mvc;
using Store.Core;
using Store.Core.Dtos;

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
            return Ok(_brandService.GetBrandList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaveBrandDto dto)
        {
            _brandService.SaveBrand(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveBrandDto dto)
        {
            _brandService.UpdateBrand(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.DeleteBrand(id);
            return Ok();
        }
    }
}
