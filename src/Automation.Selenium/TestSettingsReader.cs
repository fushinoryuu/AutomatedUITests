using System;
using System.Linq;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Automation.Database.Model;
using Automation.Selenium.Utils;

namespace Automation.Selenium
{
    internal class TestSettingsReader
    {
        private static setting GetDataFromDb()
        {
            var db = new testsettingsEntities();

            return db.settings.FirstOrDefault(item => item.isActive == 1);
        }

        public static DesiredCapabilities TargetBrowser
        {
            get
            {
                var settings = GetDataFromDb();
                BrowserType targetBrowser;

                if (settings != null)
                    Enum.TryParse(settings.targetBrowser, out targetBrowser);

                else
                    Enum.TryParse(ConfigurationManager.AppSettings["targetBrowser"], out targetBrowser);

                switch (targetBrowser)
                {
                    case BrowserType.Chrome:
                        return DesiredCapabilities.Chrome();
                    case BrowserType.Ie:
                        return DesiredCapabilities.InternetExplorer();
                    case BrowserType.Firefox:
                        return DesiredCapabilities.Firefox();
                    case BrowserType.Safari:
                        return DesiredCapabilities.Safari();
                    default:
                        return DesiredCapabilities.Chrome();
                }
            }
        }

        public static Platform OperatingSystem
        {
            get
            {
                var settings = GetDataFromDb();
                OperatingSystemType operatingSystem;

                if (settings != null)
                    Enum.TryParse(settings.operatingSystem, out operatingSystem);

                else
                    Enum.TryParse(ConfigurationManager.AppSettings["operatingSystem"], out operatingSystem);

                switch (operatingSystem)
                {
                    case OperatingSystemType.Any:
                        return new Platform(PlatformType.Any);
                    case OperatingSystemType.Linux:
                        return new Platform(PlatformType.Linux);
                    case OperatingSystemType.Mac:
                        return new Platform(PlatformType.Mac);
                    case OperatingSystemType.Windows:
                        return new Platform(PlatformType.Windows);
                    default:
                        return new Platform(PlatformType.Windows);
                }
            }
        }

        public static Uri SeleniumHubUri
        {
            get
            {
                var settings = GetDataFromDb();

                var uri = settings != null
                    ? settings.seleniumHubUri
                    : ConfigurationManager.AppSettings["seleniumHubUri"];

                return string.IsNullOrWhiteSpace(uri) ? new Uri("http://localhost:4444/wd/hub") : new Uri(uri);
            }
        }

        public static string ScreenshotFolder
        {
            get
            {
                var settings = GetDataFromDb();

                var directory = settings != null
                    ? settings.screenshotFolder
                    : ConfigurationManager.AppSettings["screenshotFolder"];

                return string.IsNullOrWhiteSpace(directory) ? "C:\\UI_Test_Screenshots\\" : directory;
            }
        }
    }
}