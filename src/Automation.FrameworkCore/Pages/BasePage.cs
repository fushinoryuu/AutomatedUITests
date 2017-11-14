using Automation.SeleniumCore.Utils;

namespace Automation.FrameworkCore.Pages
{
    public abstract class BasePage
    {
        //[FindsBy(How = How.Id, Using = "oe-logo")]
        //protected IWebElement Logo;

        protected IRunSelenium Runner;

        public abstract bool IsAt();
    }
}