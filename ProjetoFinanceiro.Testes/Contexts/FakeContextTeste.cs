using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Contexts;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Contexts
{
    public class FakeContextTeste
    {
        private readonly IContext _context;

        public FakeContextTeste()
        {
            _context = new FakeContext();
        }

        public void Execute()
        {
            TestarListagem();
            TestarInclusao();
        }

        private void TestarListagem()
        {
            List<Client> clientes = _context.ReadClients();
            foreach (Client cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.ClientId}, Nome:{cliente.Name}");
            }
        }
        private void TestarInclusao()
        {
            Client cliente = ClienteFactory.GetNovoCliente();
            cliente.ClientId = 30;
            _context.CreateClient(cliente);

            _context.ReadClients(cliente.ClientId);
        }
    }
}
