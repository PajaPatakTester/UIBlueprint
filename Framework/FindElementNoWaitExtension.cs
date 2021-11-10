using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Framework
{
    public static class FindElementNoWaitExtension
    {
        public static IWebElement FindElementNoWait(this IWebDriver webDriver, By by)
        {
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            IWebElement result = null;
            try
            {
                result = Driver.Instance.FindElement(by);
            }
            catch (Exception)
            {
                //  ignored
            }

            Driver.Instance.Manage().Timeouts().ImplicitWait = Driver.ImplicitWaitTimeout;

            return result;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsNoWait(this IWebDriver webDriver, By by)
        {
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

            var result = Driver.Instance.FindElements(by);

            Driver.Instance.Manage().Timeouts().ImplicitWait = Driver.ImplicitWaitTimeout;

            return result;
        }

    }
}
