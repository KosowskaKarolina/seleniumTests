using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.PageObjects;
using SeleniumTests.Utilities;

public class GoogleSearchTests
{
    public static void Run()
    {
        IWebDriver driver = new ChromeDriver();

        // Create instances of page objects
        GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);

        // Test steps
        googleSearchPage.OpenGooglePage();
        googleSearchPage.AcceptCookies();
        googleSearchPage.EnterSearchTerm("selenium");
        googleSearchPage.WaitForSearchResults();

        bool isSearchCorrect = googleSearchPage.AreSearchResultsCorrect("selenium");

        driver.Quit();

        // Verify the test result
        if (isSearchCorrect)
        {
            Console.WriteLine("Google Search Test successful");
        }
        else
        {
            Console.WriteLine("Google Search Test failed");
        }
    }
}
