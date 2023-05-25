using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public interface IContext
    {
        public void CreateCliente(Cliente cliente);
        public List<Cliente> ReadClientes();
        public Cliente ReadClientes(int id);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);
        public int NextId();
    }
}
