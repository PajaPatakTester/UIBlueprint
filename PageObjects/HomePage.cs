using Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class HomePage
    {
        private WelcomePopup _popup = new WelcomePopup();

        private readonly string url = "https://www.kupujemprodajem.com/";

        public IWebElement SearchField() => Driver.Instance.FindElement(By.Id("searchKeywordsInput"));
        public IList<IWebElement> SuggestedCategories() => Driver.Instance.FindElements(By.ClassName("kpACListItemLabel"));

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

        public IList<IWebElement> FetchSuggestedCategories() => SuggestedCategories();

        public IList<IWebElement> FetchSpecificCategories(string category)
        {
            IList<IWebElement> categories = new List<IWebElement>();
            foreach (IWebElement cat in FetchSuggestedCategories())
            {
                if (cat.Text.Contains(category)) categories.Add(cat);
            }
            return categories;
        }

    }
}
