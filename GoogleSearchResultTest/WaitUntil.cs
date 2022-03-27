using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchResultTest
{
    public static class WaitUntil
    {
        public static void ShouldLoad(IWebDriver webDriver, string url)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(5_000)).Until(ExpectedConditions.UrlContains(url));
            }
            catch (WebDriverTimeoutException exeprion)
            {
                throw new DllNotFoundException($"Cannot load this URL{url}", exeprion);
            }
        }

        public static void WaitSomeTime(int ms = 5_000)
        {
            Task.Delay(TimeSpan.FromMilliseconds(ms)).Wait();
        }

        public static void WaitElement(IWebDriver webDriver, By locator, int ms = 10_000) 
        {
            new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(ms)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(ms)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}

