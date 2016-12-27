using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Healthcare.Framework
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

        public void Cleanup()
        {
            RemoteDriver.Quit();
        }
    }
}