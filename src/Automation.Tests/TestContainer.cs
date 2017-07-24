using Automation.Selenium;
using Container = StructureMap.Container;
using Registry = StructureMap.Registry;

namespace Automation.Tests
{
    public class TestContainer : Container
    {
        private readonly Container _container;

        public TestContainer()
        {
            var registry = new Registry();

            registry.IncludeRegistry<SeleniumRegistry>();
            _container = new Container(registry);
        }

        public T GetContainerInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}