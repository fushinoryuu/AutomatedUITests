using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Selenium.Utils
{
    public interface IRunSelenium
    {
        WebDriverWait Wait { get; }
        IWebDriver Driver { get; }
        void Setup();
        void TakeAndSaveScreenshot(string testName);
        void Cleanup();
    }
}