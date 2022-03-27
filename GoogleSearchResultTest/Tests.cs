using GoogleSearchResultTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleSearchResultTest
{
    public class Tests : BaseTestCase
    {

        [Test]
        public void Test1()
        {
            var googleSearchTest = new GoogleSearchPage(webDriver);
            googleSearchTest
                .SetSearchField(InputData.ToSearch)
                .PressEnter()
                .AreEnoughTitles(InputData.numberOfTitles)
                .AreTitlesContainWord(InputData.ToSearch, InputData.numberOfTitles);

        }
    }
}