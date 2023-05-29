using MySql.Data.MySqlClient;
using ProjectFinance.Domain.Configuration;
using ProjectFinance.Domain.Entities;
using ProjectFinance.Domain.Enums;
using ProjectFinance.Infrastructure.Connections;
using ProjectFinance.Infrastructure.Queries;
using System.Data;

namespace ProjectFinance.Infrastructure.Contexts
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
        public void CreateClient(Domain.Entities.Client client)
        {
            MySqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.CADASTRAR_CLIENTE);
                cn = _connectionManager.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = client.Name;
                cmd.Parameters.Add("cpf_cli", MySqlDbType.VarChar).Value = client.Cpf;
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
        public List<Client> ReadClients()
        {
            List<Client> result = new List<Client>();

            MySqlConnection cn = null;

            try
            {
                cn = _connectionManager.GetConnection();
                string sql = SqlManager.GetSql(SqlQueryType.LISTAR_CLIENTE);

                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "consultaCliente");

                foreach (DataRow register in ds.Tables["consultaCliente"].Rows)
                {
                    Domain.Entities.Client cliente = new Domain.Entities.Client
                    {
                        ClientId = int.Parse(register["cod_cli"].ToString()),
                        Name = register["nome_cli"].ToString(),
                        Cpf = register["cpf_cli"].ToString()
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

        public Domain.Entities.Client ReadClients(int id)

        {
            Domain.Entities.Client result = null;
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
                    result = new Domain.Entities.Client
                    {
                        ClientId = int.Parse(item["cod_cli"].ToString()),
                        Name = item["nome_cli"].ToString(),
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
        public void UpdateClient(Domain.Entities.Client client)
        {
            MySqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.ATUALIZAR_CLIENTE);
                cn = _connectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = client.Name;
                cmd.Parameters.Add("@cpf_cli", MySqlDbType.VarChar).Value = client.Cpf;
                cmd.Parameters.Add("@cod_cli", MySqlDbType.Int32).Value = client.ClientId;

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
        public void DeleteClient(int id)
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
