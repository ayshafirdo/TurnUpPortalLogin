using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Internal;
using System.Threading;
using TurnUpPortalLogin.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver webDriver = new ChromeDriver();
       
        //Login Page Object initialization and definition
        LoginPage loginPageobj= new LoginPage();
        loginPageobj.LoginActions(webDriver,"hari","123123");

        //Home Page Object initialization and definition
        HomePage homePageobj= new HomePage();
        homePageobj.VerifyLoggedInUser(webDriver);
        homePageobj.NavigateToHomePage(webDriver);

        //TM Page Object initialization and definition
        TimeandMaterial timeandMaterialobj= new TimeandMaterial();
        timeandMaterialobj.CreateNewTimeRecord(webDriver);
        timeandMaterialobj.VerifyNewlyCreatedTimeRecord(webDriver);

        //Edit Newly Created Time Record
        TimeandMaterial editTimeobj = new TimeandMaterial();
        editTimeobj.EditNewTimeRecord(webDriver);
        editTimeobj.VerifyEditedTimeRecord(webDriver);

        //Delete Time Record
        TimeandMaterial delTimeobj = new TimeandMaterial();
        delTimeobj.DeleteTimeRecord(webDriver);
        delTimeobj.VerifyDeleteTimeRecord(webDriver);





























    }
}