using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automation.NewDatabaseCore
{
    public static class DbHelpers
    {
        public static AutomationDatabaseContext OpenDbConnection(IConfiguration configuration, string connectionName = "DefaultConnection")
        {
            var builder = new DbContextOptionsBuilder<AutomationDatabaseContext>();
            var connectionString = configuration.GetConnectionString(connectionName);

            builder.UseSqlServer(connectionString);

            return new AutomationDatabaseContext(builder.Options);
        }
    }
}
