using System.IO;
using System.Linq;
using Automation.Xml.Data;

namespace Automation.Xml
{
    public class AppConfigWriter
    {
        private readonly string _browser;
        private readonly string _os;
        private readonly string _hub;
        private readonly string _screenshots;

        public AppConfigWriter()
        {
            var settings = GetDataFromDb();

            if (settings == null)
                return;

            _browser = settings.targetBrowser;
            _os = settings.operatingSystem;
            _hub = settings.seleniumHubUri;
            _screenshots = settings.screenshotFolder;
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

        public void OutputXml()
        {
            const string srcPath = @"C:\AutomatedUiTests\src\Automation.Tests\App.config";
            const string binPath = @"C:\AutomatedUiTests\src\Automation.Tests\bin\Debug\App.config";
            var text = FileText();

            File.WriteAllText(srcPath, text);
            File.WriteAllText(binPath, text);
        }

        private string FileText()
        {
            var text = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "\n<configuration>" +
                "\n\t<appSettings >" +
                $"\n\t\t<add key=\"targetBrowser\" value=\"{_browser}\"/>" +
                $"\n\t\t<add key=\"operatingSystem\" value=\"{_os}\"/>" +
                $"\n\t\t<add key=\"seleniumHubUri\" value=\"{_hub}\"/>" +
                $"\n\t\t<add key=\"screenshotFolder\" value=\"{_screenshots}\"/>" +
                "\n\t</appSettings>" +
                "\n</configuration>";

            return text;
        }
    }
}