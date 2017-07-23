using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Selenium.Utils
{
    public interface IRunSelenium
    {
        WebDriverWait Wait { get; }
        IWebDriver Driver { get; }
        IWebDriver Setup();
        void TakeAndSaveScreenshot(string testName);
        void Cleanup();
    }
}