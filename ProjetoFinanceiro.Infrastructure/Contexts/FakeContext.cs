using ProjectFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance.Infrastructure.Contexts
{
    public class FakeContext : IContext
    {
        private List<Client> _clientes;

        public FakeContext() => LoadData();

        public void CreateClient(Client cliente)
        {
            _clientes.Add(cliente);
        }

        public List<Client> ReadClients()
        {
           return _clientes
                .OrderBy(p => p.ClientId)
                .ToList();
        }

        public Client ReadClients(int id)
        {
            Client result = _clientes.FirstOrDefault(p => p.ClientId.Equals(id));

            return result;
        }

        public void UpdateClient(Client cliente)
        {
            Client objPesquisa = ReadClients(cliente.ClientId);
            _clientes.Remove(objPesquisa);

            objPesquisa = new Client 
            {
                ClientId = cliente.ClientId,
                Name = !string.IsNullOrEmpty(cliente.Name) ? cliente.Name : objPesquisa.Name,
                Cpf = !string.IsNullOrEmpty(cliente.Cpf) ? cliente.Cpf : objPesquisa.Cpf
            };
            _clientes.Add(objPesquisa);

        }

        public void DeleteClient(int id)
        {
            Client cliente = ReadClients(id);
            if(cliente != null) _clientes.Remove(cliente);
        }


        private void LoadData()
        {
            _clientes = new List<Client>();

            Client cliente = new Client
            {
                ClientId = 1,
                Name = "Thallys Cezar",
                Cpf = "12345678901"
            };
            _clientes.Add(cliente);

            cliente = new Client
            {
                ClientId = 2,
                Name = "Thullyo Cezar",
                Cpf = "09876543210"
            };
            _clientes.Add(cliente);

            cliente = new Client
            {
                ClientId = 3,
                Name = "Tulio Cezar",
                Cpf = "12312312312"
            };
            _clientes.Add(cliente);

            cliente = new Client
            {
                ClientId = 4,
                Name = "Thaynara Cezar",
                Cpf = "12341234123"
            };
            _clientes.Add(cliente);

            cliente = new Client
            {
                ClientId = 5,
                Name = "Luatine Cezar",
                Cpf = "12345123451"
            };
            _clientes.Add(cliente);
        }

        public int NextId()
        {
            int id = _clientes.Max(p => p.ClientId);
            id++;
            return id;
        }
    }
}
