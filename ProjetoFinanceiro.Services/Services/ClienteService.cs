using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;

namespace ProjetoFinanceiro.Services.Services
{
    public class ClientService
    {
        private readonly IRepositoryClient _clientRepository;

        public ClientService(IRepositoryClient clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> Listar()
        {
            return _clientRepository.Listar();
        }

        public Client Pesquisar(int id)
        {
            return _clientRepository.Pesquisar(id);
        }

        public void Salvar(Client cliente)
        {
            _clientRepository.Salvar(cliente);
        }

        public void Atualizar(Client cliente)
        {
            _clientRepository.Atualizar(cliente);
        }

        public void Excluir(int id)
        {

            if (id == 0) 
                throw new Exception("É necessário informar o Id para realizar a exclusão");

            _clientRepository.Excluir(id);
        }
    }
}