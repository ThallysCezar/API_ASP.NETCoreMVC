using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class FakeContext : IContext
    {
        private List<Cliente> _clientes;

        public FakeContext() => LoadData();

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public List<Cliente> ReadClientes()
        {
           return _clientes
                .OrderBy(p => p.ClienteId)
                .ToList();
        }

        public Cliente ReadClientes(int id)
        {
            Cliente result = _clientes.FirstOrDefault(p => p.ClienteId.Equals(id));

            return result;
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente objPesquisa = ReadClientes(cliente.ClienteId);
            _clientes.Remove(objPesquisa);

            objPesquisa = new Cliente 
            {
                ClienteId = cliente.ClienteId,
                Nome = !string.IsNullOrEmpty(cliente.Nome) ? cliente.Nome : objPesquisa.Nome,
                Cpf = !string.IsNullOrEmpty(cliente.Cpf) ? cliente.Cpf : objPesquisa.Cpf
            };
            _clientes.Add(objPesquisa);

        }

        public void DeleteCliente(int id)
        {
            Cliente cliente = ReadClientes(id);
            if(cliente != null) _clientes.Remove(cliente);
        }


        private void LoadData()
        {
            _clientes = new List<Cliente>();

            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Thallys Cezar",
                Cpf = "12345678901"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 2,
                Nome = "Thullyo Cezar",
                Cpf = "09876543210"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 3,
                Nome = "Tulio Cezar",
                Cpf = "12312312312"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 4,
                Nome = "Thaynara Cezar",
                Cpf = "12341234123"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 5,
                Nome = "Luatine Cezar",
                Cpf = "12345123451"
            };
            _clientes.Add(cliente);
        }

        public int NextId()
        {
            int id = _clientes.Max(p => p.ClienteId);
            id++;
            return id;
        }
    }
}
