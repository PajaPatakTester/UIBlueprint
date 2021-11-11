using FluentAssertions;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class SortingSteps
    {
        private HomePage _homePage = new HomePage();
        private SearchPage _searchPage = new SearchPage();


        [Given(@"He search for term '(.*)'")]
        public void GivenHeSearchForTerm(string term)
        {
            _homePage.Search(term);
        }

        [When(@"He select sorting criteria '(.*)'")]
        public void WhenHeSelectSortingCriteria(string sortingCriteria)
        {
            _searchPage.SortClick();
            _searchPage.SortingCriteriaClick(sortingCriteria);
            _searchPage.SecondarySearchClick();
        }

        [Then(@"The results on first page should be the list of products sorted by price starting from highest")]
        public void ThenTheResultsOnFirstPageShouldBeTheListOfProductsSortedByPriceStartingFromHighest()
        {
            _searchPage.FetchAddsDescriptionsAndPrices().Should().BeInDescendingOrder(x => x.Value);
        }

    }
}
