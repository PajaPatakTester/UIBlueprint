using Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PageObjects
{
    public class WelcomePopup
    {
        private IList<IWebElement> Popups() => Driver.Instance.FindElementsNoWait(By.ClassName("kpBoxContentInner"));
        private IWebElement CloseBtn() => Driver.Instance.FindElement(By.ClassName("kpBoxCloseButton"));

        public bool IsDisplayed() => Popups().Count != 0;

        public void ClosePopup()
        {
            Driver.Wait(2, () => Popups().Count != 0);
            if (IsDisplayed() == true) CloseBtn().Click();
            Driver.Wait(2, () => Popups().Count == 0);
        }
    }
}
