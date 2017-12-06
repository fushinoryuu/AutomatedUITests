using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;

namespace Automation.SeleniumCore.Utils
{
    public interface IRunSelenium
    {
        WebDriverWait Wait { get; }
        IWebDriver Driver { get; }
        void TakeAndSaveScreenshot(IConfigurationRoot configuration, string testName);
        void Cleanup();
    }
}