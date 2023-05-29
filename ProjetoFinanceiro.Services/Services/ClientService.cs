using ProjectFinance.Domain.Entities;
using ProjectFinance.Infrastructure.Repositories;

namespace ProjectFinance.Services.Services
{
    public class ClientService
    {
        #region Props/ID

        private readonly IRepositoryClient _clientRepository;

        #endregion

        #region Constructor
        public ClientService(IRepositoryClient clientRepository)
        {
            _clientRepository = clientRepository;
        }

        #endregion

        #region Get
        public List<Client> Get()
        {
            return _clientRepository.Read();
        }

        #endregion

        #region Search
        public Client Search(int id)
        {
            return _clientRepository.Search(id);
        }

        #endregion

        #region Save
        public void Save(Client client)
        {
            _clientRepository.Save(client);
        }

        #endregion

        #region Update
        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }

        #endregion

        #region Delete
        public void Delete(int id)
        {
            if (id == 0) 
                throw new Exception("É necessário informar o Id para realizar a exclusão");

            _clientRepository.Delete(id);
        }

        #endregion
    }
}