using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "https://www.oneexchange.com";
        private const string Title = "Find Healthcare Coverage at OneExchange";

        public HomePage(WebDriver webDriver)
        {
            Driver = webDriver.Driver;
            Wait = webDriver.Wait;
           PageFactory.InitElements(Driver, this); 
        }

        public void GoTo()
        {
            Driver.Url = Url;
        }


        public override bool IsAt()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Logo));

            if (Title != Driver.Title)
                throw new StaleElementReferenceException($"Homepage is not the current page, current page is: {Driver.Title}");

            return true;
        }
    }
}