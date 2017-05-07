using Healthcare.Framework;
using Healthcare.Framework.Pages;
using NUnit.Framework;

namespace Healthcare.Tests
{
    [TestFixture, Parallelizable]
    public abstract class BaseWebtest
    {
        protected WebDriver Driver;
        protected HomePage HomePage;

        [SetUp]
        public void Setup()
        {
            Driver = new WebDriver();
            HomePage = new HomePage(Driver);
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Cleanup();
        }
    }
}