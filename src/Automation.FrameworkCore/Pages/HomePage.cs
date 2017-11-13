using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Utils;

namespace Automation.FrameworkCore.Pages
{
    public class HomePage : BasePage
    {
        // TODO - PageFactory not supported in Net Core 2
        //[FindsBy(How = How.Id, Using = "UserName")]
        //protected IWebElement UserNameTextbox;

        //[FindsBy(How = How.Id, Using = "Password")]
        //protected IWebElement PasswordTextbox;

        //[FindsBy(How = How.ClassName, Using = "login-btn")]
        //protected IWebElement SignInButton;

        //[FindsBy(How = How.ClassName, Using = "alert-summary")]
        //protected IWebElement LoginError;

        //[FindsBy(How = How.XPath, Using = "//*[@id='mainContent']/div[3]/div[2]/div/a")]
        //protected IWebElement CreateAccountButton;

        protected const string UserNameTextboxLocator = "UserName";
        
        protected const string PasswordTextboxLocator = "Password";
        
        protected IWebElement SignInButton;

        [FindsBy(How = How.ClassName, Using = "alert-summary")]
        protected IWebElement LoginError;

        [FindsBy(How = How.XPath, Using = "//*[@id='mainContent']/div[3]/div[2]/div/a")]
        protected IWebElement CreateAccountButton;

        private const string Url = "https://stage.oneexchange.com";
        private const string Title = "Find Healthcare Coverage at OneExchange";

        public HomePage(IRunSelenium runner)
        {
            Runner = runner;
            //PageFactory.InitElements(runner.Driver, this);
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

        public void Login(string userName, string password)
        {
            EnterUser(userName);
            EnterPassword(password);
            ClickSignInButton();
        }

        private void EnterUser(string userName)
        {
            
            UserNameTextbox.EnterText(userName);
        }

        private void EnterPassword(string password)
        {
            PasswordTextbox.EnterText(password);
        }

        private void ClickSignInButton()
        {
            SignInButton.Click();
        }

        public bool LoginErrorIsDisplayed()
        {
            LoginError.WaitUntilDisplayed();

            return LoginError.Displayed;
        }

        public bool SigninButtonIsVisible()
        {
            return SignInButton.Displayed;
        }

        public bool CreateAccountButtonIsVisible()
        {
            return CreateAccountButton.Displayed;
        }
    }
}