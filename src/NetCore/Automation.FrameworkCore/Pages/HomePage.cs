using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Utils;
using Automation.FrameworkCore.Interfaces;

namespace Automation.FrameworkCore.Pages
{
    public class HomePagePagePage : BasePagePage, IHomePage
    {
        // TODO - PageFactory not supported in Net Core 2
        protected IWebElement UserNameTextbox => Runner.Driver.FindElement(By.Id("UserName"));
        protected IWebElement PasswordTextbox => Runner.Driver.FindElement(By.Id("Password"));
        protected IWebElement SignInButton => Runner.Driver.FindElement(By.ClassName("login-btn"));
        protected IWebElement LoginError => Runner.Driver.FindElement(By.ClassName("alert-summary"));
        protected IWebElement CreateAccountButton => Runner.Driver.FindElement(By.XPath("//*[@id='mainContent']/div[3]/div[2]/div/a"));

        private const string Url = "https://stage.oneexchange.com";
        private const string Title = "Find Healthcare Coverage at OneExchange";

        public HomePagePagePage(IRunSelenium runner)
        {
            Runner = runner;
        }

        public void GoTo()
        {
            Runner.Driver.Url = Url;
        }

        public override bool IsAt()
        {
            Runner.Wait.Until(ExpectedConditions.ElementToBeClickable(OeLogo));

            if (Title != Runner.Driver.Title)
                throw new StaleElementReferenceException(
                    $"Homepage is not the current page, current page is: {Runner.Driver.Title}");

            return true;
        }

        public void Login(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickSignInButton();
        }

        private void EnterUserName(string userName)
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