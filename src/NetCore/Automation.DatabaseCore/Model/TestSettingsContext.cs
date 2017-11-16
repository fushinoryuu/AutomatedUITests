using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Automation.DatabaseCore.Model
{
    public abstract class TestSettingsContext
    {
        public string ConnectionString { get; }

        protected TestSettingsContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public ICollection<T> WhereQuery<T>(string tableName, string property = null, string value = null) where T : new()
        {
            var list = new List<T>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var cmdString = $"SELECT * FROM {tableName}";

                if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(value))
                    cmdString += $" WHERE {property} = {value}";

                var cmd = new MySqlCommand(cmdString, connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new T());
                    }
                }

                connection.Dispose();
            }

            return list;
        }
    }
}
