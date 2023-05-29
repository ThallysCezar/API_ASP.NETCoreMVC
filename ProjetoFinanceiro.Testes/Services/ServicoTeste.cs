using ProjectFinance.Domain.Entities;
using ProjectFinance.Services.Services;
using ProjectFinance.Testes.Helpers;

namespace ProjectFinance.Testes.Services
{
    public class ServicoTeste
    {
        private readonly ClientService _clientService;

        public ServicoTeste(ClientService clientService)
        {
            _clientService = clientService;
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
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarListagemClientes()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Listagem Clientes");
            List<Client> clients = _clientService.Get();
            foreach (Client client in clients)
            {
                Console.WriteLine($"ID: {client.ClientId}, Nome: {client.Name}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Pesquisa Cliente");
            int id = 1;
            Client client = _clientService.Pesquisar(id);
            Console.WriteLine($"ID: {client.ClientId}, Nome: {client.Name}");
        }

        private void ValidarCadastroCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Cadastro Cliente");
            
            Client client = ClienteFactory.GetCliente();
            int id = client.ClientId;

            _clientService.Salvar(client);
            
            Client objPesquisa = _clientService.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Nome: {objPesquisa.Name}");
        }

        private void ValidarAtualizacaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Atualizacao Cliente");
            int id = 1;
            Client client = _clientService.Pesquisar(id);
            client.Name = "Gustavo Ricardo";
            _clientService.Atualizar(client);

            Client objPesquisa = _clientService.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Nome: {objPesquisa.Name}");

        }

        private void ValidarExclusaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Exclusao Cliente");
            int id = 12;
            _clientService.Excluir(id);

            Client cliente = _clientService.Pesquisar(id);
        }
    }
}
