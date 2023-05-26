using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;

namespace ProjetoFinanceiro.Testes.Repositories
{
    public class RepositorioTeste
    {
        private readonly IRepositoryClient _clienteRepository;

        public RepositorioTeste(IRepositoryClient clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
            List<Client> clientes = _clienteRepository.Listar();
            foreach (Client cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.ClientId}, Name: {cliente.Name}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Client cliente = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {cliente.ClientId}, Name: {cliente.Name}");
        }

        private void ValidarCadastroCliente()
        {
            Client cliente = Helpers.ClienteFactory.GetCliente();
            int id = cliente.ClientId; ;

            _clienteRepository.Salvar(cliente);
            Client objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Name: {objPesquisa.Name}");
        }

        private void ValidarAtualizacaoCliente()
        {
            int id = 1;
            Client cliente = _clienteRepository.Pesquisar(id);
            cliente.Name = "Gustavo Ricardo";
            _clienteRepository.Atualizar(cliente);

            Client objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClientId}, Name: {objPesquisa.Name}");

        }

        private void ValidarExclusaoCliente()
        {
            int id = 12;
            _clienteRepository.Excluir(id);

            Client cliente = _clienteRepository.Pesquisar(id);
        }
    }
}
