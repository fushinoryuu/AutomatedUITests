using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Automation.Selenium.Utils;
using Automation.Framework.Pages;

namespace Automation.Tests
{
    [TestFixture, Parallelizable]
    public abstract class BaseWebtest : TestContainer
    {
        protected IRunSelenium Runner;
        protected HomePage HomePage;

        [SetUp]
        public void Setup()
        {
            Runner = GetContainerInstance<IRunSelenium>();
            HomePage = new HomePage(Runner);
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
                    Runner.TakeAndSaveScreenshot(TestContext.CurrentContext.Test.Name);
                    break;
            }

            Runner.Cleanup();
        }
    }
}