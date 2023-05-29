using ProjectFinance.Domain.Entities;
using ProjectFinance.Infrastructure.Repositories;

namespace ProjectFinance.Testes.Repositories
{
    public class RepositorioTeste
    {
        private readonly IRepositoryClient _clientRepository;

        public RepositorioTeste(IRepositoryClient clienteRepository)
        {
            _clientRepository = clienteRepository;
        }

        public void Execute()
        {

            try
            {
                ValidarListagemClientes();
                ValidarPesquisaCliente();
                ValidarCadastroCliente();
                ValidarAtualizacaoCliente();
                ValidarExclusaoCliente();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ValidarListagemClientes()
        {
            List<Client> clients = _clientRepository.Read();
            foreach (Client client in clients)
            {
                Console.WriteLine($"ID: {client.ClientId}, Name: {client.Name}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Client cliente = _clientRepository.Search(id);
            Console.WriteLine($"ID: {cliente.ClientId}, Name: {cliente.Name}");
        }

        private void ValidarCadastroCliente()
        {
            Client client = Helpers.ClienteFactory.GetCliente();
            int id = client.ClientId; ;

            _clientRepository.Save(client);
            Client objPesquisa = _clientRepository.Search(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Name: {objPesquisa.Name}");
        }

        private void ValidarAtualizacaoCliente()
        {
            int id = 1;
            Client client = _clientRepository.Search(id);
            client.Name = "Gustavo Ricardo";
            _clientRepository.Update(client);

            Client objPesquisa = _clientRepository.Search(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Name: {objPesquisa.Name}");

        }

        private void ValidarExclusaoCliente()
        {
            int id = 12;
            _clientRepository.Delete(id);

            Client client = _clientRepository.Search(id);
        }
    }
}
