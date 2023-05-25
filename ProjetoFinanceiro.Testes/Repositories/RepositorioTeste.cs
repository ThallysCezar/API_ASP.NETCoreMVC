using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;

namespace ProjetoFinanceiro.Testes.Repositories
{
    public class RepositorioTeste
    {
        private readonly IClienteRepository _clienteRepository;

        public RepositorioTeste(IClienteRepository clienteRepository)
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
            List<Cliente> clientes = _clienteRepository.Listar();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            Cliente cliente = Helpers.ClienteFactory.GetCliente();
            int id = cliente.ClienteId; ;

            _clienteRepository.Salvar(cliente);
            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClienteId}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarAtualizacaoCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            cliente.Nome = "Gustavo Ricardo";
            _clienteRepository.Atualizar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClienteId}, Nome: {objPesquisa.Nome}");

        }

        private void ValidarExclusaoCliente()
        {
            int id = 12;
            _clienteRepository.Excluir(id);

            Cliente cliente = _clienteRepository.Pesquisar(id);
        }
    }
}
