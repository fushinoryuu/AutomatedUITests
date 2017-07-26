using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using Automation.Selenium.Utils;

namespace Automation.Selenium
{
    public class RunSelenium : IRunSelenium
    {
        public WebDriverWait Wait { get; }
        public IWebDriver Driver { get; }

        public RunSelenium()
        {
            Driver = SetupWebDriver();
            Driver.Manage().Window.Maximize();

            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
        }

        private static IWebDriver SetupWebDriver()
        {
            var capabilities = TestSettingsReader.TargetBrowser;
            capabilities.Platform = TestSettingsReader.OperatingSystem;

            var hub = TestSettingsReader.SeleniumHubUri;

            return new RemoteWebDriver(hub, capabilities);
        }

        public void TakeAndSaveScreenshot(string testName)
        {
            var path = MakePath();

            MakeDirectory(path);

            var image = Driver.TakeScreenshot();

            SaveScreenShot(image, testName, path);
        }

        private static string MakePath()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            return TestSettingsReader.ScreenshotFolder + $"{date}\\";
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