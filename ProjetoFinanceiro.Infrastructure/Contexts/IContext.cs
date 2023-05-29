using ProjectFinance.Domain.Entities;

namespace ProjectFinance.Infrastructure.Contexts
{
    public interface IContext
    {
        public void CreateClient(Client client);
        public List<Client> ReadClients();
        public Client ReadClients(int id);
        public void UpdateClient(Client client);
        public void DeleteClient(int id);
        public int NextId();
    }
}
