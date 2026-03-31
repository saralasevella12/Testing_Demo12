using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Testing_Demo12.Pages;
using Testing_Demo12.Utilities;

namespace Testing_Demo12.Tests
{
    [TestFixture]
    public class TM_tests : CommonDriver
    {
        [SetUp]
        public void SetupSteps()
        {
            // Open Chrome Browser
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            driver = new ChromeDriver();

            //  Login Page object initialization and definition
            LoginPage loginPageobj = new LoginPage();
            loginPageobj.LoginActions(driver);

            //  Home Page object initialization and definition
            HomePage homePageobj = new HomePage();
            homePageobj.NavigateToTMPage(driver);


        }

        [Test]
        public void CreateTime_Test()
        {
            //  TM Page object initialization and definition
            TMPage tmPageobj = new TMPage();
            tmPageobj.CreateTMRecord(driver);

        }
        [Test]
        public void EditTime_Test()
        {
            //  Edit the created record
            TMPage tmPageobj = new TMPage();
            tmPageobj.EditTMRecord(driver);
        }
        [Test]
        public void DeleteTime_Test()
        {
            //  Delete the created record
            TMPage tmPageobj = new TMPage();
            tmPageobj.DeleteTMRecord(driver);


        }
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
