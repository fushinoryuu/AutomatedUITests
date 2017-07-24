using System;
using Automation.Selenium.Utils;

namespace Automation.Tests
{
    public class RunSeleniumFixture : TestContainer
    {
        public IRunSelenium Runner;

        public RunSeleniumFixture()
        {
            Runner = GetContainerInstance<IRunSelenium>();
            Runner.Setup();
        }
    }
}