using Microsoft.AspNetCore.Mvc;
using Store.Db;
using Store.Db.dto;
using Store.Services.Interface;
using static Store.Db.Helper.Constants;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("provider")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost]
        public Response PostProvider(Provider provider)
        {
            _providerService.Save(provider);
            return new Response { Code = 200, Status = STATUS_SUCCESS, Data = STATUS_SUCCESS };
        }

        [HttpGet]
        public Response GetProviders()
        {
            return new Response { Code = 200, Status = STATUS_SUCCESS, Data = _providerService.Get() };
        }

        [HttpGet("{idProvider}")]
        public Response GetProvidersById(int idProvider)
        {
            return new Response { Code = 200, Status = STATUS_SUCCESS, Data = _providerService.GetById(idProvider) };
        }

        [HttpPut("{idProvider}")]
        public Response PutProviders(int idProvider, Provider provider)
        {
            _providerService.Update(idProvider, provider);
            return new Response { Code = 200, Status = STATUS_SUCCESS, Data = STATUS_SUCCESS };
        }

        [HttpDelete]
        public Response DeleteProviders(int idProvider)
        {
            _providerService.Delete(idProvider);
            return new Response { Code = 200, Status = STATUS_SUCCESS, Data = STATUS_SUCCESS };
        }

    }
}
