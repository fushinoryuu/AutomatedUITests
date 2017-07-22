using NUnit.Framework;
using Automation.Framework;
using Automation.Framework.Pages;

namespace Automation.Tests
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