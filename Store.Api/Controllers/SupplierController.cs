using Microsoft.AspNetCore.Mvc;
using Store.Services.Dtos;
using Store.Services.Interface;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public IActionResult PostProvider(SaveSupplierDto supplier)
        {
            _supplierService.Save(supplier);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            return Ok(_supplierService.Get());
        }

        [HttpGet("{idSupplier}")]
        public IActionResult GetProvidersById(int idSupplier)
        {
            return Ok(_supplierService.GetById(idSupplier));
        }

        [HttpPut("{idSupplier}")]
        public IActionResult PutProviders(int idSupplier, SaveSupplierDto supplier)
        {
            _supplierService.Update(idSupplier, supplier);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProviders(int idSupplier)
        {
            _supplierService.Delete(idSupplier);
            return Ok();
        }

    }
}
