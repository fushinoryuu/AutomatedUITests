using Shouldly;
using NUnit.Framework;

namespace Healthcare.Tests.UiTests
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
    }
}