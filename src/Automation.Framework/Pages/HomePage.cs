using Automation.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Automation.Selenium.Utils;

namespace Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
#pragma warning disable 649
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement _userNameTextbox;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement _passwordTextbox;

        [FindsBy(How = How.ClassName, Using = "login-btn")]
        private IWebElement _signInButton;

        [FindsBy(How = How.ClassName, Using = "alert-summary")]
        private IWebElement _loginError;
#pragma warning restore 649

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

        public void Login(string userName, string password)
        {
            EnterUser(userName);
            EnterPassword(password);
            ClickSignInButton();
        }

        private void EnterUser(string userName)
        {
            _userNameTextbox.EnterText(userName);
        }

        private void EnterPassword(string password)
        {
            _passwordTextbox.EnterText(password);
        }

        private void ClickSignInButton()
        {
            _signInButton.Click();
        }

        public bool LoginErrorIsDisplayed()
        {
            _loginError.WaitUntilDisplayed();

            return _loginError.Displayed;
        }
    }
}