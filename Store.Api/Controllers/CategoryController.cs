using Microsoft.AspNetCore.Mvc;
using Store.Db;
using Store.Services;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService service)
        {
            categoryService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryService.Get()); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            categoryService.Save(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            categoryService.Update(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
