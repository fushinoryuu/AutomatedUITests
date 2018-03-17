using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automation.NewDatabaseCore
{
    public static class DbHelpers
    {
        public static AutomationDatabaseContext OpenDbConnection(IConfiguration configuration, string connectionName = "DefaultConnection")
        {
            var builder = new DbContextOptionsBuilder<AutomationDatabaseContext>();

            builder.UseSqlServer(connectionName);

            return new AutomationDatabaseContext(builder.Options);
        }
    }
}
