using ProjectFinance.Domain.DTOs;

namespace ProjectFinance.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }

        public DtoClient ConverterParaDto()
        {
            return new DtoClient
            {
                ClientId = this.ClientId,
                Name = this.Name,
                Cpf = this.Cpf
            };
        }

        public static List<DtoClient> ConverterParaDto(List<Client> clients)
        {
            List<DtoClient> clientsDto = new List<DtoClient>();

            foreach (Client client in clients)
            {
                DtoClient dto = client.ConverterParaDto();
                clientsDto.Add(dto);
            }

            return clientsDto;
        }
    }
}
