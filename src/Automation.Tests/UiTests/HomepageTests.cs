using Shouldly;
using NUnit.Framework;

namespace Automation.Tests.UiTests
{
    [TestFixture, Parallelizable]
    public class HomepageTests : BaseWebtest
    {
        [Test]
        public void HomePageLoads()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
        }

        [Test]
        public void LoginErrorDisplays()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
            HomePage.Login("something", "somethingelse");
            HomePage.LoginErrorIsDisplayed().ShouldBeTrue();
        }
    }
}