using Xunit;
using Shouldly;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Interfaces;

namespace Automation.TestsCore.UiTests
{
    public class HomepageTests : BaseWebtest/*, ICollectionFixture<HomepageTests>*/
    {
        public HomepageTests(IRunSelenium runner, IHomePage homePage) : base(runner, homePage)
        {
        }

        [Fact/*(DisplayName = "Home Page Loads")*/]
        public void HomePageLoads()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
        }

        [Fact/*(DisplayName = "Buttons Are Visible")*/]
        public void ButtonsAreVisible()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
            HomePage.SigninButtonIsVisible().ShouldBeTrue();
            HomePage.CreateAccountButtonIsVisible().ShouldBeTrue();
        }
    }
}