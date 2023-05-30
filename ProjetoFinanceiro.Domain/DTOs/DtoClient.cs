using ProjectFinance.Domain.Entities;

namespace ProjectFinance.Domain.DTOs
{
    public class DtoClient
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }

        public Client ToEntity()
        {
            return new Client
            {
                ClientId = ClientId,
                Name = Name,
                Cpf = Cpf
            };
        }

        public static List<Client> ToDto(List<DtoClient> dtoClient)
        {
            List<Client> clients = new List<Client>();

            foreach (DtoClient client in dtoClient)
            {
                Client entity = client.ToEntity();
                clients.Add(entity);
            }
            return clients;
        }
    }
}
