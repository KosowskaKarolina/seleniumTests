using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.PageObjects;
using SeleniumTests.Utilities;

public class AutocorrectValidationTest
{
    public static void Run()
    {
        IWebDriver driver = new ChromeDriver();

        // Create instances of page objects
        AutocorrectPage autocorrectPage = new AutocorrectPage(driver);

        // Test steps
        autocorrectPage.OpenGooglePage();
        autocorrectPage.AcceptCookies();
        autocorrectPage.EnterMisspelledTerm("selnium");
        autocorrectPage.WaitForSearchResults();

        bool isAutocorrected = autocorrectPage.IsAutocorrected("selenium");

        driver.Quit();

        // Verify the test result
        if (isAutocorrected)
        {
            Console.WriteLine("Autocorrect Validation Test successful");
        }
        else
        {
            Console.WriteLine("Autocorrect Validation Test failed");
        }
    }
}
