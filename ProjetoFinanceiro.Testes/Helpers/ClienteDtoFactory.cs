using ProjetoFinanceiro.Domain.DTOs;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteDtoFactory
    {
        public static DtoClient GetClienteDto()
        {
            DtoClient client = new DtoClient
            {
                ClientId = 1,
                Name = "Thallys Cezar",
                Cpf = "12345678901"
            };

            return client;
        }
    }
}

