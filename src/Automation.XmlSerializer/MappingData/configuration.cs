using System.Linq;
using Automation.Gui.Models;

namespace Automation.XmlSerializer.MappingData
{
    public class configuration
    {
        public string Browser { get; }
        public string Os { get; }
        public string Hub { get; }
        public string Screenshots { get; }


        public configuration()
        {
            var settings = GetDataFromDb();

            Browser = settings.targetBrowser;
            Os = settings.operatingSystem;
            Hub = settings.seleniumHubUri;
            Screenshots = settings.screenshotFolder;
        }

        private static setting GetDataFromDb()
        {
            var db = new testsettingsEntities();

            var config = (from item in db.settings
                          where item.isActive == 1
                          select item).ToList().First();

            db.Dispose();

            return config;
        }
    }
}