using ProjetoFinanceiro.Domain.DTOs;
using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteDtoFactory
    {
        public static ClienteDto GetClienteDto()
        {
            ClienteDto cliente = new ClienteDto
            {
                ClienteId = 1,
                Nome = "Thallys Cezar",
                Cpf = "12345678901"
            };

            return cliente;
        }
    }
}

