using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Services.Services;
using ProjetoFinanceiro.Testes.Helpers;

namespace ProjetoFinanceiro.Testes.Services
{
    public class ServicoTeste
    {
        private readonly ClienteService _clienteService;

        public ServicoTeste(ClienteService clienteService)
        {
            _clienteService = clienteService;
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
            List<Cliente> clientes = _clienteService.Listar();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Pesquisa Cliente");
            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Cadastro Cliente");
            
            Cliente cliente = ClienteFactory.GetCliente();
            int id = cliente.ClienteId;

            _clienteService.Salvar(cliente);
            
            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClienteId}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarAtualizacaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Atualizacao Cliente");
            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            cliente.Nome = "Gustavo Ricardo";
            _clienteService.Atualizar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"ID: {objPesquisa.ClienteId}, Nome: {objPesquisa.Nome}");

        }

        private void ValidarExclusaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Servicos, Validar Exclusao Cliente");
            int id = 12;
            _clienteService.Excluir(id);

            Cliente cliente = _clienteService.Pesquisar(id);
        }
    }
}
