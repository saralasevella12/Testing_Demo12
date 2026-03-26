using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Testing_Demo12.Pages
{
    public class TMPage
    {
        // store timestamp at class level so other methods can access it
        private string timestamp = string.Empty;

        public void CreateTMRecord(IWebDriver driver)
        {
            // Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            // Select Time from TypeCode dropdown

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));

            typeCodeDropdown.Click();
            // Select TypeCode dropdown
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

            // Click dropdown
            wait.Until(d => d.FindElement(By.XPath("//span[@aria-owns='TypeCode_listbox']"))).Click();

            // Wait for option "Time" to appear
            IWebElement timeOption = wait.Until(d =>
                d.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[text()='Time']"))
            );

            // Use JavaScript click (important!)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", timeOption);

            //Type Code into the Code textbox
            timestamp = DateTime.Now.ToString("MMddHHmmss");
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));

            codeTextbox.SendKeys("TA_" + timestamp);

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

            if (newCode.Text == "TA_" + timestamp)
            {
                Console.WriteLine("Time record created successfully, test passed");
            }
            else
            {
                Console.WriteLine("Failed to create Time record, test failed");
            }
        }
        public void EditTMRecord(IWebDriver driver)
        {
            //  Edit the last created record 
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Clear the existing code and enter new code
            IWebElement codeTextboxEdit = driver.FindElement(By.Id("Code"));
            codeTextboxEdit.Clear();
            codeTextboxEdit.SendKeys("TA_" + timestamp + "_Edited");
            // Clear the existing description and enter new description
            IWebElement descriptionTextboxEdit = driver.FindElement(By.Id("Description"));
            descriptionTextboxEdit.Clear();
            descriptionTextboxEdit.SendKeys("TA Program Description1 Edited");

            // Clear the existing price and enter new price
            IWebElement priceTagEdit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagEdit.Click();
            IWebElement priceTextboxEdit = driver.FindElement(By.Id("Price"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(
                "arguments[0].value='15'; arguments[0].dispatchEvent(new Event('change'));",
                priceTextboxEdit
            );


            // Click on Save button
            IWebElement saveButtonEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();
            Thread.Sleep(2000);

            // Go to last page - re-find the button after save to avoid stale element
            IWebElement goToLastPageButtonAfterEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonAfterEdit.Click();

            // Check if Time record has been edited successfully

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (editedCode.Text == "TA_" + timestamp + "_Edited")
            {
                Console.WriteLine("Time record edited successfully, test passed");
            }
            else
            {
                Console.WriteLine("Failed to edit Time record, test failed");

            }
        }
        public void DeleteTMRecord(IWebDriver driver)
        {
            // Delete the last created record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(3000);

            // Accept the alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

            // Check if Time record has been deleted successfully
            // Re-find the button after page refresh to avoid stale element exception
            IWebElement goToLastPageButtonRefreshed = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonRefreshed.Click();
            Thread.Sleep(1000);

            // Check if the specific record we created still exists
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastRecordCode.Text == "TA_" + timestamp + "_Edited")
            {
                Console.WriteLine("Failed to delete Time record, test failed");
            }
            else
            {
                Console.WriteLine("Time record deleted successfully, test passed");
            }
            // Close the browser
            driver.Quit();
        }
    }
}
