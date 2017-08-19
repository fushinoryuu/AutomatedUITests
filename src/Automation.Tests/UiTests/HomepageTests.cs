using Shouldly;
using NUnit.Framework;

namespace Automation.Tests.UiTests
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
    }
}