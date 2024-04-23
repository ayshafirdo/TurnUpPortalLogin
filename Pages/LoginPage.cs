using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalLogin.Pages
{
    public class LoginPage
    {
        private readonly By usernameTextboxLocator = By.Id("UserName");
        IWebElement? usernameTextbox;
        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement? passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        IWebElement? loginButton;

        public void LoginActions(IWebDriver webDriver,string username,string password)
        {
            webDriver.Manage().Window.Maximize();
            //Launch TurnUp Portal and navigate to login
            webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");
            //Identify username textbox and enter valid username
            usernameTextbox = webDriver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);
            //Identify password textbox and enter valid password
            passwordTextbox = webDriver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);
            //Identify login button and click on login button
            loginButton = webDriver.FindElement(loginButtonLocator);
            loginButton.Click();
        }
    }
}
