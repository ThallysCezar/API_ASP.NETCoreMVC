using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Domain.Setup;
using ProjetoFinanceiro.Infrastructure.Contexts;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public class RepositoryClient : IRepositoryClient
    {
        private readonly IContext _context;
        private readonly IApiConfig _apiConfig;


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

        public void Atualizar(Client cliente)
        {
            _context.UpdateClient(cliente);
        }

        public void Excluir(int id)
        {
            _context.DeleteClient(id);
        }

        public List<Client> Listar()
        {
            return _context.ReadClients();
        }

        public Client Pesquisar(int id)
        {
            return _context.ReadClients(id);
        }

        public void Salvar(Client cliente)
        {
            if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                cliente.ClientId = _context.NextId();
            }
            _context.CreateClient(cliente);
        }
    }
}
