using System;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Healthcare.Framework.Pages
{
    public abstract class BasePage
    {
        [FindsBy(How = How.Id, Using = "oe-logo")]
        protected IWebElement Logo;

        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public abstract bool IsAt();

        public virtual void WaitForPageToLoad()
        {
            WaitForPageToLoad(500);
        }

        protected void WaitForPageToLoad(int millisecondsSleep)
        {
            Wait.Until(driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(millisecondsSleep);

            WaitForAjax();
            Thread.Sleep(millisecondsSleep);
        }

        // WaitForAjax method should be called as a last resort. Try to use explicit waits for elements instead
        protected void WaitForAjax(int secondsTimeout = 5)
        {
            var isjQueryDefined = (bool)((IJavaScriptExecutor)Driver).ExecuteScript("return (typeof jQuery != 'undefined')");

            if (isjQueryDefined)
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsTimeout)).Until(
                    driver => ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));

            }
        }

        public virtual void WaitUntilDisplayed(IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(TargetInvocationException));
            wait.Message = "Element was not displayed within timeout of " + timeoutSeconds + " seconds";

            wait.Until(d =>
            {
                //If the NoSuchElementException isn't caught here, VS will annoy you while debugging by stopping execution and
                //letting you know it was thrown, even though it's handled in WebDriverWait.
                try
                {
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public virtual void WaitUntilDisplayed(By by, int timeoutSeconds = 30)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                Message = "Could not find element with By " + by + " within timeout of " + timeoutSeconds + " seconds"
            }.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public virtual void WaitUntilExists(By by, int timeoutSeconds = 30)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(ExpectedConditions.ElementExists(by));
        }

        public virtual void WaitUntilExists(IWebElement element, int timeoutSeconds = 30)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                Message = "Element was not displayed within timeout of " + timeoutSeconds + " seconds"
            }.Until(d =>
            {
                try
                {
                    var accessElement = "element " + element + " can be accessed, so it exists";
                    return accessElement.Length > 0;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public virtual bool ElementExists(IWebElement element)
        {
            try
            {
                //Just need to try to access the element
                if (element.Displayed)
                {
                    return true;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public virtual void WaitUntilDisplayedAndEnabled(IWebElement element, int timeoutSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //unfortunately, the element can't be attached to the error message, because it might not exist yet and would throw NoSuchElementException before waiting for it
            wait.Message = "Element was not displayed and enabled within timeout of " + timeoutSeconds + " seconds";

            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public virtual void WaitUntilNotExists(IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(TargetInvocationException));
            wait.Message = "Element did not disappear within timeout of " + timeoutSeconds + " seconds";

            wait.Until(d =>
            {
                //If the NoSuchElementException isn't caught here, VS will annoy you while debugging by stopping execution and
                //letting you know it was thrown, even though it's handled in WebDriverWait. :(
                try
                {
                    return !element.Displayed;
                }
                catch (Exception ex)
                {
                    if (ex is NoSuchElementException)
                    {
                        return true;
                    }
                    if (ex is TargetInvocationException || ex is StaleElementReferenceException)
                    {
                        return false;
                    }

                    //Should never get here, if we get here than the wait will swallow the stack trace :(
                    throw;
                }
            });
        }
    }
}