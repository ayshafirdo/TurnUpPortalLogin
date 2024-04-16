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
            TimeandMaterial timeandMaterialobj = new TimeandMaterial();
            timeandMaterialobj.CreateNewTimeRecord(webDriver);
            timeandMaterialobj.VerifyNewlyCreatedTimeRecord(webDriver);

        }
       [Test,Order(2)]
        public void TestEditTMRecord() 
        {

            //Edit Newly Created Time Record
            TimeandMaterial editTimeobj = new TimeandMaterial();
            editTimeobj.EditNewTimeRecord(webDriver);
            editTimeobj.VerifyEditedTimeRecord(webDriver);
        }
        [Test,Order(3)]
        public void TestDeleteTMRecord() 
        {
            //Delete Time Record
            TimeandMaterial delTimeobj = new TimeandMaterial();
            delTimeobj.DeleteTimeRecord(webDriver);
            delTimeobj.VerifyDeleteTimeRecord(webDriver);

        }
        [TearDown]
        public void CloseTestRun()
        {
        }
    }
}
