using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public class ClienteFactory
    {
        public static Cliente GetCliente()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Thallys Cezar",
                Cpf = "12345678901"
            };

            return cliente;
        }

        public static Cliente GetNovoCliente()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 12,
                Nome = "Maravilhandra",
                Cpf = "87653912721"
            };

            return cliente;
        }
    }
}
