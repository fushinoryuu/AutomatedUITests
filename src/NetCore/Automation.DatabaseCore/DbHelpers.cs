using System.Linq;
using Automation.DatabaseCore.Model;
using Microsoft.Extensions.Configuration;

namespace Automation.DatabaseCore
{
    public static class DbHelpers
    {
        public static void DeactivateAll()
        {
            var connectionString = GetConnectionString();

            var db = TestSettingsFactory.Create(connectionString);
            var toUpdate = db.Settings.Where(setting => setting.IsActive == 1).ToList();

            toUpdate.ForEach(item => item.IsActive = 0);

            db.SaveChanges();
            db.Dispose();
        }

        public static int GetNextId()
        {
            var connectionString = GetConnectionString();

            var db = TestSettingsFactory.Create(connectionString);
            var items = db.Settings.OrderBy(item => item.Id).ToList();

            db.Dispose();

            return !items.Any() ? 1 : items.Last().Id++;
        }

        private static string GetConnectionString()
        {
            var configuration = GetConfiguration();

            return configuration.GetConnectionString("DefaultConnection");
        }

        private static IConfigurationRoot GetConfiguration()
        {
            // TODO - Remove this once dependency inject is working
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            return builder.Build();
        }
    }
}