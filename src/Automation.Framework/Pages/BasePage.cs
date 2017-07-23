using Automation.Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

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