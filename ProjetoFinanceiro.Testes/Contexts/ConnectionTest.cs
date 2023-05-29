using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjectFinance.Infrastructure.Connections;
using System.Data;

namespace ProjectFinance.Testes.Contexts
{
    public class ConnectionTest
    {
        private readonly ConnectionManager _connectionManager;
        private readonly IConfiguration _configuration;

        public ConnectionTest(IConfiguration configuration)
        {
            _configuration = configuration;
            string connStr = _configuration["ApiConfig:ConnectionStrings:projfinancdb"];

            _connectionManager = new ConnectionManager(connStr);
        }

        public void Execute()
        {
            //ValidarConectividadeBancoDeDados();
            ValidarConsultaSimples();
        }

        private void ValidarConectividadeBancoDeDados()
        {
            MySqlConnection connection = null;

            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        private void ValidarConsultaSimples()
        {
            MySqlConnection connection = null;

            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();

                string sql_select = "SELECT * FROM projfinancdb.tb_cliente;";

                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql_select, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "consulta");

                foreach (DataRow linha in ds.Tables["consulta"].Rows)
                {
                    string nome = linha["nome_cli"].ToString();
                }

                ds = null;
                da = null;
                cmd = null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}
