using Shouldly;
using NUnit.Framework;

namespace Automation.TestsCore.UiTests
{
    [TestFixture, Parallelizable]
    public class HomepageTests : BaseWebtest
    {
        [TestCase(TestName = "Home Page Loads")]
        public void HomePageLoads()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
        }

        [TestCase(TestName = "Buttons Are Visible")]
        public void ButtonsAreVisible()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
            HomePage.SigninButtonIsVisible().ShouldBeTrue();
            HomePage.CreateAccountButtonIsVisible().ShouldBeTrue();
        }
    }
}