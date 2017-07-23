using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Automation.Framework.Utils
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
                    case BrowserType.Firefox:
                        return DesiredCapabilities.Firefox();
                    default:
                        return DesiredCapabilities.Chrome();
                }
            }
        }

        public static Platform OperatingSystem
        {
            get
            {
                var operatingSystem = ConfigurationManager.AppSettings["operatingSystem"];

                switch (operatingSystem)
                {
                    case "Any":
                        return new Platform(PlatformType.Any);
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

                return new Uri(uri ?? "http://localhost:4444/wd/hub");
            }
        }

        public static string ScreenshotFolder
        {
            get
            {
                var directory = ConfigurationManager.AppSettings["screenshotFolder"];

                return directory ?? "C:\\UI_Test_Screenshots\\";
            }
        }
    }
}
