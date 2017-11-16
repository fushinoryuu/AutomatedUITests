using System;
using System.Threading;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Automation.FrameworkCore.Utils
{
    internal static class WebDriverExtensions
    {
        public static void WaitUntilElementIsDisplayedAndEnabled(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            //unfortunately, the element can't be attached to the error message, because it might not exist yet and would throw NoSuchElementException before waiting for it
            wait.Message = "Element was not displayed and enabled within timeout of " + timeoutSeconds + " seconds";

            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void TypeStringIntoElement(this IWebDriver driver, IWebElement element, string keys)
        {
            element.Click();
            var builder = new Actions(driver);
            builder.MoveToElement(element).SendKeys(Keys.Home);
            builder.MoveToElement(element).SendKeys(keys).SendKeys(Keys.Return).Perform();
        }

        public static void WaitUntilElementNoLongerExists(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(TargetInvocationException));
            wait.Message = $"Element did not disappear within timeout of {timeoutSeconds} seconds.";

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
                        return true;

                    if (ex is TargetInvocationException || ex is StaleElementReferenceException)
                        return false;

                    //Should never get here, if we get here than the wait will swallow the stack trace :(
                    throw;
                }
            });

        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 30))
                .Until(d =>
                    (
                        (IJavaScriptExecutor)driver)
                    .ExecuteScript("return document.readyState")
                    .Equals("complete")
                );

            WaitForAjax(driver);
        }

        // WaitForAjax method should be called as a last resort. Try to use explicit waits for elements instead        
        public static void WaitForAjax(this IWebDriver driver, int secondsTimeout = 5)
        {
            var isjQueryDefined = (bool)((IJavaScriptExecutor)driver)
                .ExecuteScript("return (typeof jQuery != 'undefined')");

            if (isjQueryDefined)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(secondsTimeout))
                    .Until(d =>
                        (
                            (IJavaScriptExecutor)driver)
                        .ExecuteScript("return jQuery.active == 0")
                    );
            }
        }

        public static void WaitUntilElementExists(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = $"Element was not displayed within timeout of: {timeoutSeconds} seconds.";
            wait.Until(d => element.Exists() && element.Enabled);
        }

        public static void WaitUntilElementExistsAndIsClickable(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => element.Exists() && element.IsEnabled());
            Thread.Sleep(5);
        }

        public static void WaitUntilElementStopsMoving(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => ElementHasStoppedMoving(element) && ElementStoppedChangingSize(element));
        }

        public static bool ElementHasStoppedMoving(IWebElement element)
        {
            var initialLocation = element.Location;
            Thread.Sleep(50);
            var afterLocation = element.Location;
            return initialLocation.Equals(afterLocation);
        }

        public static bool ElementStoppedChangingSize(IWebElement element)
        {
            var initialSize = element.Size;
            Thread.Sleep(50);
            var afterSize = element.Size;
            return initialSize.Equals(afterSize);
        }

        public static IWebElement FindElementWithinSeconds(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));

            }
            return driver.FindElement(by);
        }

        public static void WaitForAndClick(this IWebDriver driver, IWebElement element)
        {
            driver.WaitUntilElementExists(element);
            element.Click();
        }

        public static void HighlightElement(this IWebDriver driver, IWebElement element)
        {
            var originalStyle = element.GetAttribute("style");

            ((IJavaScriptExecutor)driver)
                .ExecuteScript
                (
                    "arguments[0].setAttribute('style', arguments[1]);",
                    element,
                    "border: 1px solid green; background-color: yellow; text-shadow: #3fee00 0px 0px 5px;"
                );

            Thread.Sleep(30); //This is the length of time to highlight the element.

            ((IJavaScriptExecutor)driver)
                .ExecuteScript
                (
                    "arguments[0].setAttribute('style', arguments[1]);",
                    element,
                    originalStyle
                );
        }

        public static void WaitUntilElementIsDisplayed(this IWebDriver driver, IWebElement element, int timeoutSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(TargetInvocationException));
            wait.Message = $"Element was not displayed within timeout of {timeoutSeconds} seconds.";

            wait.Until(d =>
            {
                //If the NoSuchElementException isn't caught here, VS will annoy you while debugging by stopping execution and
                //letting you know it was thrown, even though it's handled in WebDriverWait. :(
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

        public static void SwitchToLastTab(this IWebDriver driver, int tabsBeforeClick = 1)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.WindowHandles.Count > tabsBeforeClick);
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public static void CloseLastTab(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]).Close();
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public static void CloseAllButPrimaryTab(this IWebDriver driver)
        {
            var originalTab = driver.CurrentWindowHandle;
            var allTabs = driver.WindowHandles;

            foreach (string tab in allTabs)
            {
                if (tab.Equals(originalTab)) continue;

                driver.SwitchTo().Window(tab).Close();
                driver.SwitchTo().Window(originalTab);
            }
        }
    }
}