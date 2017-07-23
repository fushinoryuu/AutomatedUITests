using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Framework.Pages
{
    public abstract class BasePage
    {
        [FindsBy(How = How.Id, Using = "oe-logo")]
        protected IWebElement Logo;

        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public abstract bool IsAt();
    }
}