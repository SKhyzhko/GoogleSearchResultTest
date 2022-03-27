using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchResultTest
{
    public class BaseTestCase
    {
        protected IWebDriver webDriver;

        [OneTimeSetUp]
        protected void DoBeforeTests()
        {
            webDriver = new ChromeDriver();
        }

        [SetUp]
        protected void DoBeforeEveryTest()
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(InputData.StartUrl);
            WaitUntil.ShouldLoad(webDriver, InputData.StartUrl);
        }

        [TearDown]
        protected void DoAfterEveryTest()
        {
            webDriver.Quit();
        }
    }
}
