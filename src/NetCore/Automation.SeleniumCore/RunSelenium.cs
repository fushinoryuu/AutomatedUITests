using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using Automation.SeleniumCore.Utils;
using Microsoft.Extensions.Configuration;

namespace Automation.SeleniumCore
{
    public class RunSelenium : IRunSelenium
    {
        public WebDriverWait Wait { get; }
        public IWebDriver Driver { get; }

        public RunSelenium(IConfigurationRoot configuration)
        {
            Driver = SetupWebDriver(configuration);
            Driver.Manage().Window.Maximize();

            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
        }

        private static IWebDriver SetupWebDriver(IConfigurationRoot configuration)
        {
            var options = TestSettingsReader.DesiredBrowser(configuration);

            options.PlatformName = TestSettingsReader.DesiredOperatingSystem(configuration);

            var hub = TestSettingsReader.SeleniumHubLocation(configuration);

            return new RemoteWebDriver(hub, options.ToCapabilities());
        }

        public void TakeAndSaveScreenshot(IConfigurationRoot configuration, string testName)
        {
            var path = MakePath(configuration);

            MakeDirectory(path);

            var image = Driver.TakeScreenshot();

            SaveScreenShot(image, testName, path);
        }

        private static string MakePath(IConfigurationRoot configuration)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            return TestSettingsReader.ScreenshotFolderLocation(configuration) + $"{date}\\";
        }

        private static void MakeDirectory(string path)
        {
            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }

        private static void SaveScreenShot(Screenshot image, string testName, string path)
        {
            var time = DateTime.Now.ToString("hh-mm-ss");
            var imageLocation = $"{path}{testName}_{time}.png";

            image.SaveAsFile(imageLocation, ScreenshotImageFormat.Png);
        }

        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
