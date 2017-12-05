using System.Linq;
using Automation.DatabaseCore.Models;
using Microsoft.Extensions.Configuration;

namespace Automation.DatabaseCore
{
    public static class DbHelpers
    {
        public static TestSettingsContext OpenDbConnection(IConfiguration configuration)
        {
            return TestSettingsFactory.Create(configuration.GetConnectionString("DefaultConnection"));
        }

        public static void DeactivateAll(IConfigurationRoot configuration)
        {
            var db = OpenDbConnection(configuration);
            var toUpdate = db.Settings.Where(setting => setting.IsActive == 1).ToList();

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
    }
}