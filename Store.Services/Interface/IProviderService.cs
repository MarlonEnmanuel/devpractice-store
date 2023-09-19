using Store.Db;

namespace Store.Services.Interface
{
    public interface IProviderService
    {
        List<Provider> Get();

        Provider GetById(int idProvider);

        void Save(Provider provider);

        void Update(int idProvider, Provider provider);

        void Delete(int idProvider);
    }
}
