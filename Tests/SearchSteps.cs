using FluentAssertions;
using Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class SearchSteps
    {
        private HomePage _homePage = new HomePage();

        [Given(@"User land on home page")]
        public void GivenUserLandOnHomePage()
        {
            _homePage.LandOn();
        }

        [When(@"He perform search for term '(.*)'")]
        public void WhenHePerformSearchForTerm(string term)
        {
            _homePage.SearchTermInput(term);
        }

        [Then(@"He should see the list of suggested categories")]
        public void ThenHeShouldSeeTheListOfSuggestedCategories()
        {
            _homePage.FetchAllSuggestedCategories().Should().NotBeEmpty();
        }

        [When(@"He perform search for listed companies")]
        public void WhenHePerformSearchForListedCompanies()
        {
            // empty step but neccesary for readability of the test
            // actions are performed in ThenHeShouldSeeAdequateCategory()
        }


        [Then(@"He should see adequate category:")]
        public void ThenHeShouldSeeAdequateCategory(Table table)
        {
            var dataTable = CommonActions.TableToDataTable(table);
            foreach (DataRow row in dataTable.Rows)
            {
                _homePage.SearchTermInput(row[0].ToString());
                _homePage.FetchSuggestedCategories(row[1].ToString()).Should().NotBeEmpty();
                Log.Error($"For term {row[0]}, did not find adequate category {row[1]} ");
            }
        }

    }
}
