using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.PageObjects
{
    public class YouTubeSearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public YouTubeSearchPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void OpenGooglePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void AcceptCookies()
        {
            try
            {
                IWebElement acceptButton = _driver.FindElement(By.Id("L2AGLb"));
                acceptButton.Click();
            }
            catch (NoSuchElementException)
            {
                // If the accept button is not present, proceed
            }
        }

        public void EnterSearchTerm(string searchTerm)
        {
            IWebElement searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();
        }

        public void WaitForSearchResults()
        {
            _wait.Until(driver =>
            {
                try
                {
                    IWebElement searchResultsContainer = driver.FindElement(By.Id("search"));
                    return searchResultsContainer.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public bool IsYouTubeLinkPresent()
        {
            try
            {
                IWebElement youtubeLink = _driver.FindElement(By.CssSelector("a[href*='youtube.com']"));
                return youtubeLink != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void OpenYouTubeLink()
        {
            IWebElement youtubeLink = _driver.FindElement(By.CssSelector("a[href*='youtube.com']"));
            string youtubeUrl = youtubeLink.GetAttribute("href");

            _driver.Navigate().GoToUrl(youtubeUrl);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
