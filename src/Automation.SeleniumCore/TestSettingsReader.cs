using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using Automation.SeleniumCore.Utils;

namespace Automation.SeleniumCore
{
    internal class TestSettingsReader
    {
        /// <summary>Tries to figureout what browser to use from the config file.</summary>
        public static DriverOptions TargetBrowser
        {
            get
            {
                // TODO - Add db query
                BrowserType targetBrowser;

                Enum.TryParse("Something", out targetBrowser);

                switch (targetBrowser)
                {
                    case BrowserType.Chrome:
                        return new ChromeOptions();
                    case BrowserType.InternetExplorer:
                        return new InternetExplorerOptions();
                    case BrowserType.Firefox:
                        return new FirefoxOptions();
                    case BrowserType.Safari:
                        return new SafariOptions();
                    default:
                        return new ChromeOptions();
                }
            }
        }

        /// <summary>Tries to figureout what OS to use from the config file.</summary>
        public static Platform OperatingSystem
        {
            get
            {
                // TODO - Add db query
                OperatingSystemType operatingSystem;

                Enum.TryParse("Something", out operatingSystem);

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

        /// <summary>Tries to figureout the url of the Selenium Hub.</summary>
        public static Uri SeleniumHubUri
        {
            get
            {
                // TODO - Update with db query
                const string hubLocation = " ";

                return string.IsNullOrWhiteSpace(hubLocation) ? new Uri("http://localhost:4444/wd/hub") : new Uri(hubLocation);
            }
        }

        /// <summary>Tries to figereout where the screenshots should be saved to.</summary>
        public static string ScreenshotFolder
        {
            get
            {
                // TODO - Update with db query
                const string folderLocation = " ";

                return string.IsNullOrWhiteSpace(folderLocation) ? "C:\\UI_Test_Screenshots\\" : folderLocation;
            }
        }
    }
}
