using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (testStatus)
            {
                case TestStatus.Failed:
                case TestStatus.Inconclusive:
                case TestStatus.Warning:
                    Driver.TakeAndSaveScreenshot(TestContext.CurrentContext.Test.Name);
                    break;
            }

            Driver.Cleanup();
        }
    }
}