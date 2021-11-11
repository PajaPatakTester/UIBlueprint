using Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class SearchPage
    {
        private IWebElement SortBtn() => Driver.Instance.FindElement(By.Id("orderSecondSelection"));
        private IWebElement SecondarySearchBtn() => Driver.Instance.FindElement(By.CssSelector("input.secondarySearchButton"));
        private IList<IWebElement> AddDescriptions() => Driver.Instance.FindElements(By.CssSelector("[id^='adDescription']"));


        public void SortClick() => SortBtn().Click();
        public void SortingCriteriaClick(string criteria)
        {
            var theSelector = Driver.Instance.FindElement(By.CssSelector($"[data-text='{criteria}']"));
            theSelector.Click();
        }
        public void SecondarySearchClick() => SecondarySearchBtn().Click();

        public Dictionary<string, decimal> FetchAddsDescriptionsAndPrices()
        {
            var nameAndPrice = new Dictionary<string, decimal>();
            var homePage = new HomePage();
            
            var exchangeRate = homePage.FetchMiddleExchangeRate();

            foreach (IWebElement add in AddDescriptions())
            {
                var name = add.FindElement(By.ClassName("adName")).Text;
                var description = add.FindElement(By.ClassName("adDescription")).Text;
                
                var priceAsString = add.FindElement(By.ClassName("adPrice")).Text;
                var price = CommonActions.PriceInEur(priceAsString, exchangeRate);

                nameAndPrice.Add($"{name}; {description}", price);
            }
            return nameAndPrice;
        }
        public Dictionary<string, Decimal> AddsOrderedByHighestPrice()
        {
            var orderedDict = FetchAddsDescriptionsAndPrices().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return orderedDict;
        }
    }
}
