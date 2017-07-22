using System;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace Automation.Framework
{
    public class WebDriver
    {
        public IWebDriver RemoteDriver { get; }
        public WebDriverWait Wait { get; }

        public WebDriver()
        {
            RemoteDriver = Setup();
            RemoteDriver.Manage().Window.Maximize();

            Wait = new WebDriverWait(RemoteDriver, new TimeSpan(0, 0, 30));
        }

        private static IWebDriver Setup()
        {
            var capabilities = DesiredCapabilities.Chrome();
            capabilities.Platform = Platform.CurrentPlatform;
            var hub = new Uri("http://localhost:4444/wd/hub");

            return new RemoteWebDriver(hub, capabilities);
        }

        public void TakeScreenshot(string testName, string providedPath = null)
        {
            var userName = Environment.UserName;
            var date = DateTime.Now.ToString("yy-MM-dd");
            var dateAndTime = date + "_" + DateTime.Now.TimeOfDay;

            // This will either save the screenshot to the desktop or the provided path
            var path = providedPath ?? $"C:/Users/{userName}/Desktop/UI_Test_Screenshots_{date}/";

            MakeDirectory(path);
            SaveScreenShot(testName, path, dateAndTime);
        }

        private static void MakeDirectory(string path)
        {
            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }

        private void SaveScreenShot(string testName, string path, string dateAndTime)
        {
            var imageLocation = path + testName + dateAndTime + ".png";
            RemoteDriver.TakeScreenshot().SaveAsFile(imageLocation, ImageFormat.Png);
        }

        public void Cleanup()
        {
            RemoteDriver.Quit();
        }
    }
}