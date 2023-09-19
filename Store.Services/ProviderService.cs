using Microsoft.EntityFrameworkCore;
using Store.Db;
using Store.Services.Interface;

namespace Store.Services
{
    public class ProviderService : IProviderService
    {
        private readonly StoreDBContext _context;


        public ProviderService(StoreDBContext context)
        {
            _context = context;
        }

        public void Delete(int idProvider)
        {
            Provider oProvider = getProviderById(idProvider);
            if (oProvider != null)
            {
                _context.Providers.Remove(oProvider);
                _context.SaveChanges();
            }
        }

        public List<Provider> Get()
        {
            return _context.Providers.ToList();
        }

        public Provider GetById(int idProvider)
        {
            return getProviderById(idProvider);
        }

        public void Save(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        public void Update(int idProvider, Provider provider)
        {
            Provider oProvider = getProviderById(idProvider);
            if (oProvider != null)
            {
                oProvider.RucProvider = provider.RucProvider;
                oProvider.BusinessName = provider.BusinessName;
                _context.Entry(oProvider).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        private Provider getProviderById(int idProvider)
        {
           return _context.Providers.ToList().FirstOrDefault(e => e.Id == idProvider);
        }
    }
}
