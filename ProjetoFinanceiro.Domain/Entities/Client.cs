using ProjectFinance.Domain.DTOs;

namespace ProjectFinance.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }

        public DtoClient ToDto()
        {
            return new DtoClient
            {
                ClientId = ClientId,
                Name = Name,
                Cpf = Cpf
            };
        }

        public static List<DtoClient> ToDto(List<Client> clients)
        {
            List<DtoClient> clientsDto = new List<DtoClient>();

            foreach (Client client in clients)
            {
                DtoClient dto = client.ToDto();
                clientsDto.Add(dto);
            }

            return clientsDto;
        }
    }
}
