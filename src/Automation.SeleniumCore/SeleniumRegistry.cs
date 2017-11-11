using StructureMap;
using Automation.SeleniumCore.Utils;

namespace Automation.SeleniumCore
{
    public class SeleniumRegistry : Registry
    {
        public SeleniumRegistry()
        {
            For<IRunSelenium>().Use<RunSelenium>();
        }
    }
}
