using Automation.Selenium;
using Registry = StructureMap.Registry;
using Container = StructureMap.Container;

namespace Automation.Tests
{
    public abstract class TestContainer : Container
    {
        private readonly Container _container;

        protected TestContainer()
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