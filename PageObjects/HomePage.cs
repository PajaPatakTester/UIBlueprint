using Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class HomePage
    {
        private WelcomePopup _popup = new WelcomePopup();

        private readonly string url = "https://www.kupujemprodajem.com/";

        private IWebElement SearchField() => Driver.Instance.FindElement(By.Id("searchKeywordsInput"));
        private IList<IWebElement> SuggestedCategories() => Driver.Instance.FindElements(By.ClassName("kpACListItemLabel"));
        private IWebElement InputExchangeAmmountField() => Driver.Instance.FindElement(By.Id("nbsAmount"));
        private IWebElement CalculatedExchangeField() => Driver.Instance.FindElement(By.Id("nbsConverted"));

        public void GoTo() => Driver.Instance.Navigate().GoToUrl(url);

        public void LandOn()
        {
            GoTo();
            _popup.ClosePopup();
        }

        public void Search(string productName)
        {
            SearchField().Clear();
            SearchField().SendKeys(productName);
            SearchField().SendKeys(Keys.Enter);
        }

        public void SearchTermInput(string productName)
        {
            SearchField().Clear();
            SearchField().SendKeys(productName);
            Driver.Wait(5, () => SuggestedCategories().First().Text.Contains(productName), $"Categories with term \"{productName}\" to be displayed.");
        }

        public IList<IWebElement> FetchAllSuggestedCategories() => SuggestedCategories();

        public IList<IWebElement> FetchSuggestedCategories(string category)
        {
            IList<IWebElement> categories = new List<IWebElement>();
            foreach (IWebElement cat in FetchAllSuggestedCategories())
            {
                if (cat.Text.Contains(category)) categories.Add(cat);
            }
            return categories;
        }

        public Decimal FetchMiddleExchangeRate()
        {
            InputExchangeAmmountField().Clear();
            InputExchangeAmmountField().SendKeys(1.ToString());
            var exchangeRate = CommonActions.FormatPrice(CalculatedExchangeField().Text);
            return exchangeRate;
        }
    }
}
