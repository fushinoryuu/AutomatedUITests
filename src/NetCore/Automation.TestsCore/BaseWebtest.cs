using Xunit;
using Automation.SeleniumCore;
using Automation.SeleniumCore.Utils;
using Automation.FrameworkCore.Pages;
using Automation.FrameworkCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.TestsCore
{
    public abstract class BaseWebtest : ICollectionFixture<BaseWebtest>
    {
        protected IConfigurationRoot Configuration { get; }
        protected IRunSelenium Runner;
        protected IHomePage HomePage;

        protected BaseWebtest(IRunSelenium runner, IHomePage homePage)
        {
            // Load config file
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            Runner = runner;
            HomePage = homePage;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setup Dependency Injection
            services.AddSingleton<IRunSelenium, RunSelenium>();
            services.AddTransient<IHomePage, HomePagePagePage>();
        }
        public void Cleanup()
        {
            Runner.Cleanup();
        }
    }
}
