using Automation.DatabaseCore.Model;

namespace Automation.DatabaseCore
{
    public static class DbHelpers
    {
        public static void DeactivateAll()
        {
            var settingsDb = new SettingsContext("server=localhost;database=testsettings;user id=root;password=root");
            var toUpdate = settingsDb.WhereQuery("isActive", "1");

            foreach (var item in toUpdate)
                item.IsActive = 0;
        }
    }
}