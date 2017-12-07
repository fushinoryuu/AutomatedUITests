using StructureMap;
using Automation.Selenium.Utils;

namespace Automation.Selenium
{
    public class SeleniumRegistry : Registry
    {
        public SeleniumRegistry()
        {
            For<IRunSelenium>().Use<RunSelenium>();
        }
    }
}