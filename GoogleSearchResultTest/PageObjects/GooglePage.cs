using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchResultTest.PageObjects
{
    class GooglePage
    {
        private IWebDriver webDriver;

        private readonly By GetArticleTitle = By.XPath("//h3[@class='LC20lb MBeuO DKV0Md']");

        public GooglePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public GooglePage AreEnoughTitles(int expectedNumberOfTitles, bool expected = true)
        {
            WaitUntil.WaitElement(webDriver, GetArticleTitle);
            var data = webDriver.FindElements(GetArticleTitle).Select(title => title.Text).ToList().Count;
            Assert.AreEqual(data >= expectedNumberOfTitles, expected, "Verify number of titles is less than expected");
            return new GooglePage(webDriver); 
        }

        public GooglePage AreTitlesContainWord(string subString, int expectedNumberOfTitles, bool expected = true)
        {
            WaitUntil.WaitElement(webDriver, GetArticleTitle);
            var data = webDriver.FindElements(GetArticleTitle).Select(title => title.Text).ToList();
            for (int index = 0; index < expectedNumberOfTitles; index++)
            {
                Assert.AreEqual(data[index].ToLower().Contains(subString.ToLower()), expected, $"String {data[index]} does not contains substing {subString}");
            }
            return new GooglePage(webDriver);
        }
    }
}
