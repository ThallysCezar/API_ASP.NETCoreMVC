using ProjectFinance.Domain.Entities;

namespace ProjectFinance.Infrastructure.Repositories
{
    public interface IRepositoryClient
    {
        public void Save(Client client);
        public void Update(Client client);
        public void Delete(int id);
        public Client Search(int id);
        public List<Client> Read();

    }
}
