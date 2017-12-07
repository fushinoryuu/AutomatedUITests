using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automation.DatabaseCore
{
    public static class DbHelpers
    {
        public static TestSettingsContext OpenDbConnection(IConfiguration configuration)
        {
            return CreateDbContext(configuration.GetConnectionString("DefaultConnection"));
        }

        public static void DeactivateAll(IConfigurationRoot configuration)
        {
            var db = OpenDbConnection(configuration);
            var toUpdate = db.Settings.Where(setting => setting.IsActive == 1).ToList();

            // Set all items 0 for the IsActive column
            toUpdate.ForEach(item => item.IsActive = 0);

            db.SaveChanges();
            db.Dispose();
        }

        public static int GetNextId(IConfigurationRoot configuration)
        {
            var db = OpenDbConnection(configuration);
            var items = db.Settings.OrderBy(item => item.Id).ToList();

            db.Dispose();

            return !items.Any() ? 1 : items.Last().Id++;
        }

        public static TestSettingsContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestSettingsContext>();

            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new TestSettingsContext(optionsBuilder.Options);

            //context.Database.EnsureCreated();

            return context;
        }
    }
}