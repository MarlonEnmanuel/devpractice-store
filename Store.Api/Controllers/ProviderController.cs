using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Db;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("provider")]
    public class ProviderController : ControllerBase
    {
        private StoreDBContext _context;

        public ProviderController(StoreDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void CreateProviders(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<Provider> GetProviders()
        {
            return _context.Providers.ToList();
        }

        [HttpGet("{idProvider}")]
        public Provider? GetProvidersById(int idProvider)
        {
            return _context.Providers.ToList().Where(e => e.Id == idProvider).FirstOrDefault();
        }

        [HttpPut("{idProvider}")]
        public void PutProviders(int idProvider, Provider provider)
        {
            Provider oProvider = _context.Providers.ToList().Where(e => e.Id == idProvider).FirstOrDefault();
            if(oProvider != null)
            {
                oProvider.RucProvider = provider.RucProvider;
                oProvider.BusinessName = provider.BusinessName;
                _context.Entry(oProvider).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteProviders(int idProvider)
        {
            Provider oProvider = _context.Providers.ToList().Where(e => e.Id == idProvider).FirstOrDefault();
            if(oProvider != null)
            {
                _context.Providers.Remove(oProvider);
                _context.SaveChanges();
            }
        }

    }
}
