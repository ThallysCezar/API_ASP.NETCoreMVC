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
            List<Cliente> clientes = _context.ReadClientes();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Id: {cliente.ClienteId}, Nome:{cliente.Nome}");
            }
        }
        private void TestarInclusao()
        {
            Cliente cliente = ClienteFactory.GetNovoCliente();
            cliente.ClienteId = 30;
            _context.CreateCliente(cliente);

            _context.ReadClientes(cliente.ClienteId);
        }
    }
}
