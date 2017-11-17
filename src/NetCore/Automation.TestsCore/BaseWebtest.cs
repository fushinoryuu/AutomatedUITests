using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Automation.SeleniumCore;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Automation.TestsCore
{
    [TestFixture, Parallelizable]
    public abstract class BaseWebtest
    {
        protected IConfigurationRoot Configuration { get; }
        protected IRunSelenium Runner;
        protected HomePage HomePage;

        protected BaseWebtest()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        [SetUp]
        public void Setup()
        {
            Runner = new RunSelenium();
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
