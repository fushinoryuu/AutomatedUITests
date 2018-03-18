using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using Automation.NewDatabaseCore;
using Automation.SeleniumCore.Utils;
using Automation.NewDatabaseCore.Model;
using Microsoft.Extensions.Configuration;

namespace Automation.SeleniumCore
{
    internal class TestSettingsReader
    {
        private static TestConfiguration GetDataFromDb(IConfiguration configuration)
        {
            // TODO: Fix this

            //var db = DbHelpers.OpenDbConnection(configuration);
            //var setting = db. //.FirstOrDefault(item => item.IsActive == 1);

            //db.Dispose();

            //return setting;

            throw new NotImplementedException();
        }

        /// <summary>Tries to figureout what browser to use from the db or config file.</summary>
        /// <param name="configuration">The configuration objected holding all the desired settings.</param>
        /// <returns>The driver options to use in the new instance of a driver.</returns>
        public static DriverOptions DesiredBrowser(IConfigurationRoot configuration)
        {
            var setting = GetDataFromDb(configuration);
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
        public static string DesiredOperatingSystem(IConfigurationRoot configuration)
        {
            var setting = GetDataFromDb(configuration);
            OperatingSystemType operatingSystem;

            if (setting != null)
                Enum.TryParse(setting.OperatingSystem, out operatingSystem);

            else
                Enum.TryParse(configuration["operatingSystem"], out operatingSystem);

            switch (operatingSystem)
            {
                case OperatingSystemType.Any:
                    return new Platform(PlatformType.Any).ToString();
                case OperatingSystemType.Linux:
                    return new Platform(PlatformType.Linux).ToString();
                case OperatingSystemType.Mac:
                    return new Platform(PlatformType.Mac).ToString();
                case OperatingSystemType.Windows:
                    return new Platform(PlatformType.Windows).ToString();
                default:
                    return new Platform(PlatformType.Windows).ToString();
            }
        }

        /// <summary>Tries to figureout the url of the Selenium Hub.</summary>
        public static Uri SeleniumHubLocation(IConfigurationRoot configuration)
        {
            var setting = GetDataFromDb(configuration);
            var location = setting != null ? setting.SeleniumHubUri : configuration["seleniumHubUri"];

            return string.IsNullOrWhiteSpace(location) ? new Uri("http://localhost:4444/wd/hub") : new Uri(location);
        }

        /// <summary>Tries to figereout where the screenshots should be saved to.</summary>
        public static string ScreenshotFolderLocation(IConfigurationRoot configuration)
        {
            // TODO: Fix this

            //var setting = GetDataFromDb(configuration);
            //var directory = setting != null ? setting.ScreenshotFolder : configuration["screenshotFolder"];

            //return string.IsNullOrWhiteSpace(directory) ? "C:\\UI_Test_Screenshots\\" : directory;

            return "C:\\UI_Test_Screenshots\\";
        }
    }
}
