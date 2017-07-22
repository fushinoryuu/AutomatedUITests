using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Utils
{
    public static class Extensions
    {
        public static void WaitForAttributeToVanish(this IWebElement element, string attributeName, string vanishingValue)
        {
            string attribute;
            try
            {
                attribute = element.GetAttribute(attributeName);
                if (attribute == null) return;
            }
            catch (Exception)
            {
                return;
            }
            var count = 0;
            while (attribute.ToLower().Contains(vanishingValue) && count < 24)
            {
                try
                {
                    attribute = element.GetAttribute(attributeName);
                }
                catch (Exception)
                {
                    return;
                }
                count++;
                Thread.Sleep(250);
            }
        }

        public static void WaitForAttributeToAppear(this IWebElement element, string attributeName, string appearingValue)
        {
            var attribute = element.GetAttribute(attributeName);
            var count = 0;
            while (!attribute.ToLower().Contains(appearingValue) && count < 24)
            {
                attribute = element.GetAttribute(attributeName);
                count++;
                Thread.Sleep(250);
            }
        }

        public static void WaitForStyleAttributeToStopChanging(this IWebElement element, string styleAttribute)
        {
            //split style string into attributes and values then locate the desired attribute.
            var itemAttributes = element.GetAttribute("style").Split(new[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var attribute = string.Empty;
            var attributeIndex = 1;
            for (; attributeIndex < itemAttributes.Length; attributeIndex++)
            {
                if (!itemAttributes[attributeIndex - 1].Contains(styleAttribute)) continue;
                attribute = itemAttributes[attributeIndex];
                break;
            }
            //wait for value of attribute to maintain the same value.
            var count = 0;
            while (element.GetAttribute("style").Split(new[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries)[attributeIndex] != attribute && count < 20)
            {
                attribute =
                    element.GetAttribute("style").Split(new[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries)[attributeIndex];
                Debug.Print(attribute);
                Thread.Sleep(100);
                count++;
            }
        }

        public static void WaitUntilDisplayed(this IWebElement element)
        {
            Thread.Sleep(2500);

            var count = 0;
            while (!element.Displayed && count < 40)
            {
                Thread.Sleep(100);
                count++;
            }
        }

        public static void EnterText(this IWebElement element, string text)
        {

            element.Click();
            element.Clear();
            element.SendKeys(text);

            element.Click();
        }

        public static void Select(this IWebElement element, string text, string ifNullSelect = null)
        {
            if (text == null) text = ifNullSelect;
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void Select(this IWebElement element, Enum givenEnum, string ifNullSelect = null)
        {
            if (givenEnum == null)
                new SelectElement(element).SelectByText(ifNullSelect);

            new SelectElement(element).SelectByEnum(givenEnum);
        }

        public static void Select(this IWebElement element, int index)
        {
            new SelectElement(element).SelectByIndex(index);
        }

        public static SelectElement ComboBox(this IWebElement element)
        {
            return new SelectElement(element);
        }

        public static void SelectByEnum(this SelectElement selectElement, Enum givenEnum)
        {
            selectElement.SelectByText(givenEnum.ToString());
        }

        public static ReadOnlyCollection<IWebElement> ContainAttribute(this ReadOnlyCollection<IWebElement> collection, string attributeName, string value)
        {
            var list = collection.Where(element => element.GetAttribute(attributeName).ToLower().Contains(value.ToLower())).ToList();
            return new ReadOnlyCollection<IWebElement>(list);
        }
        
        public static ReadOnlyCollection<IWebElement> FindElementAndContainers(this RemoteWebDriver driver, params By[] searchMechanisms)
        {
            var elements = new List<IWebElement>(searchMechanisms.Length) { driver.FindElement(searchMechanisms[0]) };

            for (var index = 1; index < searchMechanisms.Length; index++)
            {
                var searchMechanism = searchMechanisms[index];
                elements.Add(elements[index - 1].FindElement(searchMechanism));
            }
            return new ReadOnlyCollection<IWebElement>(elements);
        }

        public static IWebElement FindElementByContainers(this RemoteWebDriver driver, params By[] searchMechanisms)
        {
            var elements = driver.FindElementAndContainers(searchMechanisms);
            return elements[elements.Count - 1];
        }

        public static IWebElement FindElementByPartialAttribute(this IWebElement element, By by, string attributeName, string value)
        {
            return
                element.FindElements(by).FirstOrDefault(
                    e => e.GetAttribute(attributeName).ToLower().Contains(value));
        }

        public static IWebElement FindElementByPartialAttribute(this RemoteWebDriver driver, By by, string attributeName, string value)
        {
            return
                driver.FindElements(by).FirstOrDefault(
                    e => e.GetAttribute(attributeName).ToLower().Contains(value));
        }

        public static IWebElement RefindElementAfterDomRefresh(this RemoteWebDriver driver, IWebElement element, By by)
        {
            element.WaitForDomRefresh();
            return driver.FindElement(by);
        }

        public static void WaitForDomRefresh(this IWebElement element)
        {
            var count = 0;
            var refreshed = false;
            while (!refreshed && count < 20)
            {
                try
                {
                    var displayed = element.Displayed;
                }
                catch (Exception)
                {
                    refreshed = true;
                }
                Thread.Sleep(10);
                count++;
            }
        }
    }
}