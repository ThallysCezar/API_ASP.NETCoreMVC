using ProjetoFinanceiro.Domain.DTOs;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Testes.Helpers;

namespace ProjetoFinanceiro.Testes.Domain
{
    public class DominiosTestes
    {
        public void Execute()
        {
            TestarEntidade();
            TestarDto();
            TestarSconversaoEntidadeParaDto();
            TestarConversaoDtoParaEntidade();
        }

        private void TestarEntidade()
        {
            Client cliente = ClienteFactory.GetCliente();

            string message = $"ID: {cliente.ClientId}, com o Name de {cliente.Name} com o CPF:{cliente.Cpf}";

            Console.WriteLine(message);
        }

        private void TestarDto()
        {
            DtoClient cliente = ClienteDtoFactory.GetClienteDto();

            string message = $"ID: {cliente.ClientId}, com o Name de {cliente.Name} com o CPF:{cliente.Cpf}";

            Console.WriteLine(message);
        }

        private void TestarSconversaoEntidadeParaDto()
        {
            Client cliente = ClienteFactory.GetCliente();

            DtoClient dto = cliente.ConverterParaDto();

            string message = $"ID: {dto.ClientId}, com o Name de {dto.Name}";

            Console.WriteLine(message);
        }

        private void TestarConversaoDtoParaEntidade()
        {
            DtoClient cliente = ClienteDtoFactory.GetClienteDto();

            Client entidade = cliente.ConverterParaEntidade();

            string message = $"ID: {entidade.ClientId}, com o Name de {entidade.Name}";

            Console.WriteLine(message);
        }
    }
}
