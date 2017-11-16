using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.SeleniumCore.Utils
{
    public interface IRunSelenium
    {
        WebDriverWait Wait { get; }
        IWebDriver Driver { get; }
        void TakeAndSaveScreenshot(string testName);
        void Cleanup();
    }
}