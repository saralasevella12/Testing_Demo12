using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Testing_Demo12.Utilities
{
    public class Wait
    {
        //Generic function to wait for an element to be clickable
#pragma warning disable format
        public static void WaitToBeClickable(IWebDriver driver,string locatorType,string locatorValue,int seconds)

#pragma warning disable format
        {
           var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            if (locatorType == "XPath")
                {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                 }
            else if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));

             }

        }
        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            else if (locatorType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }

        }
    }


}


    
