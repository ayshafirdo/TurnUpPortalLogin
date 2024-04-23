using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalLogin.Pages;
using TurnUpPortalLogin.Utilities;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace TurnUpPortalLogin.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TimeMaterialTests:CommonDriver
    {
        [OneTimeSetUp]
        public void SetUpTimeMaterial()
        {
            //Open Chrome Browser
           webDriver = new ChromeDriver();

            //Login Page Object initialization and definition
            LoginPage loginPageobj = new LoginPage();
            loginPageobj.LoginActions(webDriver, "hari", "123123");
            //Home Page Object initialization and definition
            HomePage homePageobj = new HomePage();
            homePageobj.VerifyLoggedInUser(webDriver);
            homePageobj.NavigateToHomePage(webDriver);

        }
        [Test,Order(1)]
        public void TestCreateTMRecord()
        {
            //TM Page Object initialization and definition
            TimeandMaterialPage timeandMaterialobj = new TimeandMaterialPage();
            timeandMaterialobj.CreateNewTimeRecord(webDriver);
            timeandMaterialobj.VerifyNewlyCreatedTimeRecord(webDriver);

        }
       [Test,Order(2)]
        public void TestEditTMRecord() 
        {

            //Edit Newly Created Time Record
            TimeandMaterialPage editTimeobj = new TimeandMaterialPage();
            editTimeobj.EditNewTimeRecord(webDriver);
           editTimeobj.VerifyEditedTimeRecord(webDriver);
        }
        [Test,Order(3)]
        public void TestDeleteTMRecord() 
        {
            //Delete Time Record
            TimeandMaterialPage delTimeobj = new TimeandMaterialPage();
            delTimeobj.DeleteTimeRecord(webDriver);
            delTimeobj.VerifyDeleteTimeRecord(webDriver);

        }
        [TearDown]
        public void CloseTestRun()
        {
            webDriver.Quit();
            
        }
    }
}
