using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalLogin.Pages
{
    public class HomePage
    {
        private readonly By administrationDropdownLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        IWebElement? administrationDropdown;
        private readonly By tmOptionLocator = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        IWebElement? tmOption;


        public void NavigateToHomePage(IWebDriver webDriver) 
        {
            //Navigate to Administration and click on it
            administrationDropdown = webDriver.FindElement(administrationDropdownLocator);
            administrationDropdown.Click();
            WebDriverWait driverWait = new WebDriverWait(webDriver,TimeSpan.FromSeconds(5));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tmOptionLocator));
            
            //Select Time and Material
            tmOption = webDriver.FindElement(tmOptionLocator);
            tmOption.Click();
        }
        public void VerifyLoggedInUser(IWebDriver webDriver)
        {
            //Check if user has logged in successfully
            IWebElement hellohari = webDriver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (hellohari.Text == "Hello hari!")
            { Console.WriteLine("Successfully logged in"); }
            else { Console.WriteLine("not logged in"); }
        }
    }
}
