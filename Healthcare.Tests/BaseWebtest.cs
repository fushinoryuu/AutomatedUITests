using System;
using Healthcare.Framework;
using Healthcare.Framework.Pages;

namespace Healthcare.Tests
{
    public abstract class BaseWebtest : IDisposable
    {
        protected WebDriver WebDriver;
        protected HomePage HomePage;
        
        protected BaseWebtest()
        {
            WebDriver = new WebDriver();
            HomePage = new HomePage(WebDriver);
        }

        public void Dispose()
        {
            WebDriver.Cleanup();
        }
    }
}