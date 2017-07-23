using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Automation.Selenium.Utils;

namespace Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "https://www.oneexchange.com";
        private const string Title = "Find Healthcare Coverage at OneExchange";

        public HomePage(IRunSelenium runner)
        {
            Runner = runner;
            PageFactory.InitElements(runner.Driver, this);
        }

        public void GoTo()
        {
            Runner.Driver.Url = Url;
        }


        public override bool IsAt()
        {
            Runner.Wait.Until(ExpectedConditions.ElementToBeClickable(Logo));

            if (Title != Runner.Driver.Title)
                throw new StaleElementReferenceException(
                    $"Homepage is not the current page, current page is: {Runner.Driver.Title}");

            return true;
        }
    }
}