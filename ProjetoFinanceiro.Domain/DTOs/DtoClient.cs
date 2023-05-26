using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Domain.DTOs
{
    public class DtoClient
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }

        public Client ConverterParaEntidade()
        {
            return new Client
            {
                ClientId = this.ClientId,
                Name = this.Name,
                Cpf = this.Cpf
            };
        }

        public static List<Client> ConverterParaDto(List<DtoClient> dtoClient)
        {
            List<Client> clients = new List<Client>();

            foreach (DtoClient client in dtoClient)
            {
                Client entity = client.ConverterParaEntidade();
                clients.Add(entity);
            }

            return clients;
        }
    }
}
