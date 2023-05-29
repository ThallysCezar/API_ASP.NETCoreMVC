using ProjectFinance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinance.Infrastructure.Queries
{
    public class SqlManager
    {
        public static string GetSql(SqlQueryType queryType)
        {
            string sql = "";

            switch (queryType)
            {
                case SqlQueryType.LISTAR_CLIENTE:
                    sql = "SELECT * FROM projfinancdb.tb_cliente;";
                    break;

                case SqlQueryType.PESQUISAR_CLIENTE:
                    sql = "SELECT * FROM projfinancdb.tb_cliente WHERE cod_cli = @cod_cli;";
                    break;

                case SqlQueryType.ATUALIZAR_CLIENTE:
                    sql = "UPDATE tb_cliente SET nome_cli = @nome_cli, cpf_cli = @cpf_cli WHERE cod_cli = @cod_cli;";
                    break;

                case SqlQueryType.CADASTRAR_CLIENTE:
                    sql = "INSERT INTO tb_cliente (nome_cli, cpf_cli) VALUES(@nome_cli, @cpf_cli);";
                    break;

                case SqlQueryType.EXCLUIR_CLIENTE:
                    sql = "DELETE FROM tb_cliente WHERE cod_cli = @cod_cli;";
                    break;
            }

            return sql;
        }
    }
}
