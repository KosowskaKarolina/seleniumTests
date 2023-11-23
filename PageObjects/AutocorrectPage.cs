﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.PageObjects
{
    public class AutocorrectPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AutocorrectPage(IWebDriver driver)
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

        public void EnterMisspelledTerm(string misspelledTerm)
        {
            IWebElement searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys(misspelledTerm);
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

        public bool IsAutocorrected(string correctedTerm)
        {
            var searchResultsContainer = _driver.FindElement(By.Id("search"));
            var searchResults = searchResultsContainer.FindElements(By.CssSelector("div.g"));

            bool isAutocorrected = false;
            foreach (var result in searchResults)
            {
                string resultText = result.Text.ToLower();
                if (resultText.Contains(correctedTerm.ToLower()))
                {
                    isAutocorrected = true;
                    break;
                }
            }

            return isAutocorrected;
        }
    }
}
