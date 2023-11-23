using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.PageObjects;
using SeleniumTests.Utilities;

public class YouTubeLinkTest
{
    public static void Run()
    {
        IWebDriver driver = new ChromeDriver();

        // Create instances of page objects
        YouTubeSearchPage youTubeSearchPage = new YouTubeSearchPage(driver);

        // Test steps
        youTubeSearchPage.OpenGooglePage();
        youTubeSearchPage.AcceptCookies();
        youTubeSearchPage.EnterSearchTerm("selenium");
        youTubeSearchPage.WaitForSearchResults();

        bool isYouTubeLinkPresent = youTubeSearchPage.IsYouTubeLinkPresent();

        if (isYouTubeLinkPresent)
        {
            youTubeSearchPage.OpenYouTubeLink();
        }

        driver.Quit();

        // Verify the test result
        if (isYouTubeLinkPresent)
        {
            Console.WriteLine("YouTube Link Presence Test successful");
        }
        else
        {
            Console.WriteLine("YouTube Link Presence Test failed");
        }
    }
}
