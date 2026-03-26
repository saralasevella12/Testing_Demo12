using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Testing_Demo12.Pages;

public class Program
{
    public static void Main(string[] args)
#pragma warning disable format
    {

        // Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        IWebDriver driver = new ChromeDriver(options);

       
        //  Login Page object initialization and definition
        LoginPage loginPageobj = new LoginPage();
        loginPageobj.LoginActions(driver);

        //  Home Page object initialization and definition
        HomePage homePageobj = new HomePage();
        homePageobj.NavigateToTMPage(driver);

        //  TM Page object initialization and definition
        TMPage tmPageobj = new TMPage();

        tmPageobj.CreateTMRecord(driver);
        //  Edit the created record
        tmPageobj.EditTMRecord(driver);
        //  Delete the created record
        tmPageobj.DeleteTMRecord(driver);

    }

}
#pragma warning restore format