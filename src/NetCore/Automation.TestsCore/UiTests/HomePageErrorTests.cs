using Xunit;
using Shouldly;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Interfaces;

namespace Automation.TestsCore.UiTests
{
    public class HomePageErrorTests : BaseWebtest
    {
        public HomePageErrorTests(IRunSelenium runner, IHomePage homePage) : base(runner, homePage)
        {
        }

        [Fact/*(DisplayName = "Login Error Displays")*/]
        public void LoginErrorDisplays()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
            HomePage.Login("something", "somethingelse");
            HomePage.LoginErrorIsDisplayed().ShouldBeTrue();
        }
    }
}