using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Automation.Selenium.Utils;

namespace Automation.Selenium
{
    internal class TestSettingsReader
    {
        public static DesiredCapabilities TargetBrowser
        {
            get
            {
                BrowserType targetBrowser;
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
                OperatingSystemType operatingSystem;
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
                var uri = ConfigurationManager.AppSettings["seleniumHubUri"];

                return string.IsNullOrWhiteSpace(uri) ? new Uri("http://localhost:4444/wd/hub") : new Uri(uri);
            }
        }

        public static string ScreenshotFolder
        {
            get
            {
                var directory = ConfigurationManager.AppSettings["screenshotFolder"];

                return string.IsNullOrWhiteSpace(directory) ? "C:\\UI_Test_Screenshots\\" : directory;
            }
        }
    }
}