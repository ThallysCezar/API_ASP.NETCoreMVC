using MySql.Data.MySqlClient;

namespace ProjectFinance.Infrastructure.Connections
{
    public class ConnectionManager
    {
        private static string ConnStr = "";

        private static MySqlConnection connection = null;

        public ConnectionManager(string connectionString)
        {
            ConnStr = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(ConnStr);
            }

            return connection;
        }
    }
}
