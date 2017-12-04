using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using Automation.SeleniumCore.Utils;
using Automation.DatabaseCore.Models;
using Microsoft.Extensions.Configuration;

namespace Automation.SeleniumCore
{
    internal class TestSettingsReader
    {
        private static Setting GetDataFromDb(string connectionString)
        {
            var db = TestSettingsFactory.Create(connectionString);
            var setting = db.Settings.FirstOrDefault(item => item.IsActive == 1);

            db.Dispose();

            return setting;
        }

        /// <summary>Tries to figureout what browser to use from the db or config file.</summary>
        /// <param name="configuration">The configuration objected holding all the desired settings.</param>
        /// <returns>The driver options to use in the new instance of a driver.</returns>
        public static DriverOptions TargetBrowser(IConfigurationRoot configuration)
        {
            var setting = GetDataFromDb(configuration.GetConnectionString("DefaultConnection"));
            BrowserType targetBrowser;

            if (setting != null)
                Enum.TryParse(setting.TargetBrowser, out targetBrowser);

            else
                Enum.TryParse(configuration["targetBrowser"], out targetBrowser);

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
