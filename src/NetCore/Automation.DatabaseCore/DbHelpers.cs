using System.Linq;
using Automation.DatabaseCore.Model;
using Microsoft.Extensions.Configuration;

namespace Automation.DatabaseCore
{
    public static class DbHelpers
    {
        public static void DeactivateAll()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var db = TestSettingsContext.Create(connectionString);
            var toUpdate = db.Settings.Where(setting => setting.IsActive == 1).ToList();

            toUpdate.ForEach(item => item.IsActive = 0);

            db.SaveChanges();
        }
    }
}