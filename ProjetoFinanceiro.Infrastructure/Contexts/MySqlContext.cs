using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Infrastructure.Connections;
using ProjetoFinanceiro.Infrastructure.Queries;
using System.Data;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class MySqlContext : IContext
    {
        #region Propriedades
        private readonly IApiConfig _apiConfig;

        private static string _connectionString = "";
        private readonly ConnectionManager _connectionManager;
        #endregion

        #region Construtores
        public MySqlContext(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
            _connectionString = _apiConfig.ConnectionStrings.projfinancdb;
            _connectionManager = new ConnectionManager(_connectionString);
        }
        #endregion

        #region Criacao/Create
        public void CreateCliente(Cliente cliente)
        {
            MySqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.CADASTRAR_CLIENTE);
                cn = _connectionManager.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("cpf_cli", MySqlDbType.VarChar).Value = cliente.Cpf;
                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();
            }
        }
        #endregion

        #region Leitura/Read
        public List<Cliente> ReadClientes()
        {
            List<Cliente> result = new List<Cliente>();

            MySqlConnection cn = null;

            try
            {
                cn = _connectionManager.GetConnection();
                string sql = SqlManager.GetSql(SqlQueryType.LISTAR_CLIENTE);

                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "consultaCliente");

                foreach (DataRow registro in ds.Tables["consultaCliente"].Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteId = Int32.Parse(registro["cod_cli"].ToString()),
                        Nome = registro["nome_cli"].ToString(),
                        Cpf = registro["cpf_cli"].ToString()
                    };

                    result.Add(cliente);
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn = null;
            }
        }

        public Cliente ReadClientes(int id)

        {
            Cliente result = null;
            MySqlConnection cn = null;

            try
            {
                cn = _connectionManager.GetConnection();
                string sql = SqlManager.GetSql(SqlQueryType.PESQUISAR_CLIENTE);

                DataSet ds = new DataSet();

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@cod_cli", MySqlDbType.Int32).Value = id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "pesquisaCliente");

                DataRowCollection registros = ds.Tables["pesquisaCliente"].Rows;

                foreach (DataRow item in registros)
                {
                    result = new Cliente
                    {
                        ClienteId = Int32.Parse(item["cod_cli"].ToString()),
                        Nome = item["nome_cli"].ToString(),
                        Cpf = item["cpf_cli"].ToString()
                    };
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn = null;
            }
        }
        #endregion

        #region Atualizacao/Update
        public void UpdateCliente(Cliente cliente)
        {
            MySqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.ATUALIZAR_CLIENTE);
                cn = _connectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@cpf_cli", MySqlDbType.VarChar).Value = cliente.Cpf;
                cmd.Parameters.Add("@cod_cli", MySqlDbType.Int32).Value = cliente.ClienteId;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();

                cn = null;
            }
        }
        #endregion

        #region Exclusao/Delete
        public void DeleteCliente(int id)
        {
            MySqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.EXCLUIR_CLIENTE);
                cn = _connectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@cod_cli", MySqlDbType.Int16).Value = id;
                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();

                cn = null;
            }
        }
        #endregion

        #region MetodoAuxiliares
        public int NextId()
        {
            return 0;
        }
        #endregion
    }
}
