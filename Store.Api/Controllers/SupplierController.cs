using Microsoft.AspNetCore.Mvc;
using Store.Core.Dtos;
using Store.Core.Interface;

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
            _supplierService.SaveSupplier(supplier);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            return Ok(_supplierService.GetSupplierFindAll());
        }

        [HttpGet("{idSupplier}")]
        public IActionResult GetProvidersById(int idSupplier)
        {
            return Ok(_supplierService.GetSupplierById(idSupplier));
        }

        [HttpPut("{idSupplier}")]
        public IActionResult PutProviders(int idSupplier, SaveSupplierDto supplier)
        {
            _supplierService.UpdateSupplier(idSupplier, supplier);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProviders(int idSupplier)
        {
            _supplierService.DeleteSupplier(idSupplier);
            return Ok();
        }

    }
}
