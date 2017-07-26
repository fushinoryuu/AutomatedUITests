using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Automation.Selenium.Utils;

namespace Automation.Framework.Pages
{
    public abstract class BasePage
    {
        [FindsBy(How = How.Id, Using = "oe-logo")]
        protected IWebElement Logo;

        protected IRunSelenium Runner;

        public abstract bool IsAt();
    }
}