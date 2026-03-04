using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Program
{
    public static void Main(string[] args)
    {
        
        // Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

        IWebDriver driver = new ChromeDriver(options);
        // Launch Turnup Portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // Identify username textbox and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        // Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");
        // Click on Login button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        //check if user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("Logged in successfully, test passed");
        }
        else
        {
            Console.WriteLine("Login failed, test failed");
        }
        //Create a Time and Material record

        //Navigate to Time and Material page

        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));

        administrationTab.Click();
        IWebElement timeMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

        timeMaterialOption.Click();

        // Click on Create New button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();
        // Select Time from TypeCode dropdown

        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));

        typeCodeDropdown.Click();
        // Select TypeCode dropdown
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Click dropdown
        wait.Until(d => d.FindElement(By.XPath("//span[@aria-owns='TypeCode_listbox']"))).Click();

        // Wait for option "Time" to appear
        IWebElement timeOption = wait.Until(d =>
            d.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[text()='Time']"))
        );
        
        // Use JavaScript click (important!)
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", timeOption);

        //Type Code into the Code textbox

        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));

        codeTextbox.SendKeys("TA Program1");

        //Type Description into the Description textbox
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("TA Program Description1");

        //Type Price  into the Price textbox
        IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTag.Click();
        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("12");
        //Click on Save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);
        // Check if Time record has been created successfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "TA Program1")
        {
            Console.WriteLine("Time record created successfully, test passed");
        }
        else
        {
            Console.WriteLine("Failed to create Time record, test failed");
        }
    }
}