using ProjetoFinanceiro.Testes.Contexts;
using ProjetoFinanceiro.Testes.Domain;
using ProjetoFinanceiro.Testes.Repositories;
using ProjetoFinanceiro.Testes.Services;

namespace ProjetoFinanceiro.Testes.Applications
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly ServicoTeste _servicoTeste;
        private readonly ConnectionTest _connectionTest;

        public AppTestePrincipal(RepositorioTeste repositorioTeste, ServicoTeste servicoTeste, ConnectionTest connectionTest)
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
            _connectionTest = connectionTest;
        }
        public void Execute()
        {
            //ValidarCamadaDominio();
            //ValidarCamadaEstrutura_Context();
            //ValidarCamadaRepositorio();
            //ValidarCamadaServicos();
            ValidarConectividade();
        }

        private void ValidarCamadaEstrutura_Context()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.Execute();
        }

        private void ValidarCamadaDominio()
        {
            DominiosTestes teste = new DominiosTestes();
            teste.Execute();
        }

        private void ValidarCamadaRepositorio()
        {
            _repositorioTeste.Execute();
        }

        private void ValidarCamadaServicos()
        {
            _servicoTeste.Execute();
        }

        private void ValidarConectividade()
        {
            _connectionTest.Execute();
        }
    }
}
