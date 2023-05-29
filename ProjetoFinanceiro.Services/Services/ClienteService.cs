using ProjectFinance.Domain.Entities;
using ProjectFinance.Infrastructure.Repositories;

namespace ProjectFinance.Services.Services
{
    public class ClientService
    {
        private readonly IRepositoryClient _clientRepository;

        public ClientService(IRepositoryClient clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> Get()
        {
            return _clientRepository.Read();
        }

        public Client Pesquisar(int id)
        {
            return _clientRepository.Search(id);
        }

        public void Save(Client client)
        {
            _clientRepository.Save(client);
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }

        public void Delete(int id)
        {

            if (id == 0) 
                throw new Exception("É necessário informar o Id para realizar a exclusão");

            _clientRepository.Delete(id);
        }
    }
}