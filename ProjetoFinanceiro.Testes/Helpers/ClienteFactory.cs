using ProjectFinance.Domain.Entities;

namespace ProjectFinance.Testes.Helpers
{
    public class ClienteFactory
    {
        public static Client GetCliente()
        {
            Client cliente = new Client
            {
                ClientId = 1,
                Name = "Thallys Cezar",
                Cpf = "12345678901"
            };

            return cliente;
        }

        public static Client GetNovoCliente()
        {
            Client cliente = new Client
            {
                ClientId = 12,
                Name = "Maravilhandra",
                Cpf = "87653912721"
            };

            return cliente;
        }
    }
}
