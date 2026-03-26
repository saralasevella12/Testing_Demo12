using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using OpenQA.Selenium;
using Testing_Demo12.Utilities;

namespace Testing_Demo12.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //Navigate to Time and Material page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);


            IWebElement timeMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialOption.Click();

        }

    }
}
