using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using static System.Configuration.ConfigurationManager;

namespace Automation.Selenium.Utils
{
    internal class TestSettingsReader
    {
        public static DesiredCapabilities TargetBrowser
        {
            get
            {
                BrowserType targetBrowser;
                Enum.TryParse(AppSettings["targetBrowser"], out targetBrowser);

                // ReSharper disable once SwitchStatementMissingSomeCases
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
                var operatingSystem = AppSettings["operatingSystem"];

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
                var uri = AppSettings["seleniumHubUri"];

                return string.IsNullOrWhiteSpace(uri) ? new Uri("http://localhost:4444/wd/hub") : new Uri(uri);
            }
        }

        public static string ScreenshotFolder
        {
            get
            {
                var directory = AppSettings["screenshotFolder"];

                return directory ?? "C:\\UI_Test_Screenshots\\";
            }
        }
    }
}
