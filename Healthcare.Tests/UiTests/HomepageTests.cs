using Xunit;
using Shouldly;

namespace Healthcare.Tests.UiTests
{
    public class HomepageTests : BaseWebtest
    {
        [Fact]
        public void HomePageLoads()
        {
            HomePage.GoTo();
            HomePage.IsAt().ShouldBeTrue();
        }
    }
}