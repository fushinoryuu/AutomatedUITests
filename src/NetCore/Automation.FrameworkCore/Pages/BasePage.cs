using OpenQA.Selenium;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Interfaces;

namespace Automation.FrameworkCore.Pages
{
    public abstract class BasePage : IBase
    {
        // TODO - PageFactory not supported in Net Core 2
        protected IWebElement OeLogo => Runner.Driver.FindElement(By.Id("oe-logo"));

        protected IRunSelenium Runner;

        public abstract bool IsAt();
    }
}