using MySql.Data.MySqlClient;

namespace Automation.DatabaseCore.Model
{
    public abstract class TestSettingsContext
    {
        public string ConnectionString { get; }

        protected TestSettingsContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
