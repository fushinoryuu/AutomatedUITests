using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automation.DatabaseCore
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

        public static void DeactivateAll(IConfiguration configuration)
        {
            var db = OpenDbConnection(configuration);
            var activeItems = db.TestConfigurations.Where(item => item.IsActive == 1).ToList();

            // Set all items in the list to 0
            activeItems.ForEach(item => item.IsActive = 0);

            db.SaveChanges();
            db.Dispose();
        }

        public static int GetNextId(IConfiguration configuration)
        {
            var db = OpenDbConnection(configuration);
            var allTestConfigs = db.TestConfigurations.OrderBy(item => item.ConfigId).ToList();

            db.Dispose();

            return !allTestConfigs.Any() ? 1 : allTestConfigs.Last().ConfigId++;
        }
    }
}
