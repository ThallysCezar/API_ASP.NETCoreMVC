using ProjectFinance.Domain.Configuration;
using ProjectFinance.Domain.Entities;
using ProjectFinance.Domain.Enums;
using ProjectFinance.Domain.Setup;
using ProjectFinance.Infrastructure.Contexts;

namespace ProjectFinance.Infrastructure.Repositories
{
    public class RepositoryClient : IRepositoryClient
    {
        #region Props/ID

        private readonly IContext _context;
        private readonly IApiConfig _apiConfig;

        #endregion

        #region Constructor
        public RepositoryClient(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;

            switch (ConfiguracoesApp.SELECTED_DATABASE)
            {
                case DatabaseType.Fake:
                    _context = new FakeContext();
                    break;

                case DatabaseType.MySql:
                    _context = new MySqlContext(_apiConfig);
                    break;
            }
        }

        #endregion

        #region Update
        public void Update(Client client)
        {
            _context.UpdateClient(client);
        }

        #endregion

        #region Delete
        public void Delete(int id)
        {
            _context.DeleteClient(id);
        }

        #endregion

        #region Read
        public List<Client> Read()
        {
            return _context.ReadClients();
        }

        #endregion

        #region Search
        public Client Search(int id)
        {
            return _context.ReadClients(id);
        }

        #endregion

        #region Save
        public void Save(Client client)
        {
            if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                client.ClientId = _context.NextId();
            }
            _context.CreateClient(client);
        }

        #endregion
    }
}
