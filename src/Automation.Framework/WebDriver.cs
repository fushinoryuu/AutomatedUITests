using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace Automation.Framework
{
    public class WebDriver
    {
        public IWebDriver Driver { get; }
        public WebDriverWait Wait { get; }

        public WebDriver()
        {
            Driver = Setup();
            Driver.Manage().Window.Maximize();

            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
        }

        private static IWebDriver Setup()
        {
            var capabilities = DesiredCapabilities.Chrome();
            capabilities.Platform = Platform.CurrentPlatform;
            var hub = new Uri("http://localhost:4444/wd/hub");

            return new RemoteWebDriver(hub, capabilities);
        }

        public void TakeAndSaveScreenshot(string testName, string providedPath = null)
        {
            var userName = Environment.UserName;
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var dateAndTime = date + "_" + DateTime.Now.TimeOfDay;

            // This will either save the screenshot to the desktop or the provided path
            var path = providedPath ?? $"C:/Users/{userName}/Desktop/UI_Test_Screenshots/{date}/";

            MakeDirectory(path);
            var image = TakeScreenshot();
            SaveScreenShot(image, testName, path, dateAndTime);
        }

        private static void MakeDirectory(string path)
        {
            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }

        public Screenshot TakeScreenshot()
        {
            return Driver.TakeScreenshot();
        }

        private static void SaveScreenShot(Screenshot image, string testName, string path, string dateAndTime)
        {
            var imageLocation = path + testName + dateAndTime + ".png";
            image.SaveAsFile(imageLocation, ScreenshotImageFormat.Png);
        }

        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}