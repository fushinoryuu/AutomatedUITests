using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Automation.DatabaseCore.Model
{
    public class SettingsContext : TestSettingsEntities
    {
        public SettingsContext(string connectionString) : base(connectionString)
        {
        }

        public ICollection<Setting> WhereQuery(string tableName, string property = null, string value = null)
        {
            var list = new List<Setting>();

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
                        list.Add(new Setting(reader));
                }

                connection.Dispose();
            }

            return list;
        }
    }
}
