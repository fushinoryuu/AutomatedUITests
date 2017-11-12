using Automation.SeleniumCore.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Automation.TestsCore
{
    [TestFixture, Parallelizable]
    public abstract class BaseWebtest : TestContainer
    {
        protected IRunSelenium Runner;

        [SetUp]
        public void Setup()
        {
            Runner = GetContainerInstance<IRunSelenium>();
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
