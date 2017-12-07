using Shouldly;
using NUnit.Framework;

namespace Automation.Tests.UiTests
{
    [TestFixture, Parallelizable]
    public class HomePageErrorTests : BaseWebtest
    {
        [TestCase(TestName = "Login Error Displays")]
        public void LoginErrorDisplays()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
            HomePage.Login("something", "somethingelse");
            HomePage.LoginErrorIsDisplayed().ShouldBeTrue();
        }
    }
}