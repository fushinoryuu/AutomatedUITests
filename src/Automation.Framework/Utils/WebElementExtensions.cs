using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Utils
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Waits for an element undergoing a change to complete the event. Ex: The cart slides down the page while opening and slides off the page while closing.
        /// Will wait up to a maximum of 5 seconds before returning.
        /// </summary>
        /// <param name="element">The element performing a change</param>
        /// <param name="attributeName">The name of the attribute that contains the change: "style"</param>
        /// <param name="vanishingValue">The value that will no longer be present after the change is complete: "block;" changes to "none;"</param>
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
                if (!itemAttributes[attributeIndex - 1].Contains(styleAttribute))
                    continue;

                attribute = itemAttributes[attributeIndex];

                break;
            }

            //wait for value of attribute to maintain the same value.
            var count = 0;

            while (element.GetAttribute("style").Split(new[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries)[attributeIndex] != attribute && count < 20)
            {
                attribute = element.GetAttribute("style").Split(new[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries)[attributeIndex];
                Debug.Print(attribute);
                count++;
            }
        }

        public static void WaitUntilDisplayed(this IWebElement element)
        {
            var count = 0;

            while (!element.Displayed && count < 40)
            {
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

        /// <summary>
        /// Selects an item in element by the displayed text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text">calls SelectByText() there is another SelectByValue() provided for SelectElement.</param>
        /// <param name="ifNullSelect"></param>
        public static void Select(this IWebElement element, string text, string ifNullSelect = null)
        {
            if (text == null)
                text = ifNullSelect;

            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        /// <summary>
        /// Selects an item in element by the equivalent string representation of an Enum.
        /// </summary>
        public static void Select(this IWebElement element, Enum givenEnum, string ifNullSelect = null)
        {
            if (givenEnum == null)
                new SelectElement(element).SelectByText(ifNullSelect);

            new SelectElement(element).SelectByEnum(givenEnum);
        }

        /// <summary>
        /// Selects and item in element by index.
        /// </summary>
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

        public static IWebElement FindElementByPartialAttribute(this IWebElement element, By by, string attributeName, string value)
        {
            return
                element.FindElements(by).FirstOrDefault(
                    e => e.GetAttribute(attributeName).ToLower().Contains(value));
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

                count++;
            }
        }

        public static bool Exists(this IWebElement element)
        {
            try
            {
                //Just need to try to access the element
                if (element.Displayed)
                {
                    return true;
                }
            }

            catch (StaleElementReferenceException)
            {
                return false;
            }

            catch (NoSuchElementException)
            {
                return false;
            }

            catch (NullReferenceException)
            {
                return false;
            }

            return true;
        }

        public static bool IsEnabled(this IWebElement element)
        {
            // TODO: Find a way to removed the "disabled" part of this, and rely on just .Enabled.
            return element.Enabled && !element.GetAttribute("class").Contains("disabled");
        }
    }
}