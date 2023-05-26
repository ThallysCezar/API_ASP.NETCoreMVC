using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public interface IRepositoryClient
    {
        public void Salvar(Client cliente);
        public void Atualizar(Client cliente);
        public void Excluir(int id);
        public Client Pesquisar(int id);
        public List<Client> Listar();

    }
}
