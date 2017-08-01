using System.Linq;
using Automation.XmlWriter.Data;

namespace Automation.XmlWriter
{
    public class Configuration
    {
        public string Browser { get; }
        public string Os { get; }
        public string Hub { get; }
        public string Screenshots { get; }


        public Configuration()
        {
            var settings = GetDataFromDb();

            if (settings == null)
                return;

            Browser = settings.targetBrowser;
            Os = settings.operatingSystem;
            Hub = settings.seleniumHubUri;
            Screenshots = settings.screenshotFolder;
        }

        private static setting GetDataFromDb()
        {
            var db = new xmlTestSettingsEntities();

            var config = (from item in db.settings
                          where item.isActive == 1
                          select item).ToList().FirstOrDefault();

            db.Dispose();

            return config;
        }
    }
}