using MySql.Data.MySqlClient;

namespace Automation.DatabaseCore.Model
{
    public abstract class TestSettingsEntities
    {
        public string ConnectionString { get; }

        protected TestSettingsEntities(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
