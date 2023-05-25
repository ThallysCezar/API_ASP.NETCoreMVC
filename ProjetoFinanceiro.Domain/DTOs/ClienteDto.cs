using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Domain.DTOs
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }

        public Cliente ConverterParaEntidade()
        {
            return new Cliente
            {
                ClienteId = this.ClienteId,
                Nome = this.Nome,
                Cpf = this.Cpf
            };
        }

        public static List<Cliente> ConverterParaDto(List<ClienteDto> clientesDto)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (ClienteDto cliente in clientesDto)
            {
                Cliente entidade = cliente.ConverterParaEntidade();
                clientes.Add(entidade);
            }

            return clientes;
        }
    }
}
