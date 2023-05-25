using ProjetoFinanceiro.Domain.DTOs;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Cliente cliente = ClienteFactory.GetCliente();

            string message = $"ID: {cliente.ClienteId}, com o nome de {cliente.Nome} com o CPF:{cliente.Cpf}";

            Console.WriteLine(message);
        }

        private void TestarDto()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();

            string message = $"ID: {cliente.ClienteId}, com o nome de {cliente.Nome} com o CPF:{cliente.Cpf}";

            Console.WriteLine(message);
        }

        private void TestarSconversaoEntidadeParaDto()
        {
            Cliente cliente = ClienteFactory.GetCliente();

            ClienteDto dto = cliente.ConverterParaDto();

            string message = $"ID: {dto.ClienteId}, com o nome de {dto.Nome}";

            Console.WriteLine(message);
        }

        private void TestarConversaoDtoParaEntidade()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();

            Cliente entidade = cliente.ConverterParaEntidade();

            string message = $"ID: {entidade.ClienteId}, com o nome de {entidade.Nome}";

            Console.WriteLine(message);
        }
    }
}
