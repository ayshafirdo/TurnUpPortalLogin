using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Internal;

//Open Chrome Browser
IWebDriver webDriver = new ChromeDriver();
webDriver.Manage().Window.Maximize();
//Launch TurnUp Portal and navigate to login
webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");
//Identify username textbox and enter valid username
IWebElement usernameTextbox = webDriver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");
//Identify password textbox and enter valid password
IWebElement passwordTextbox = webDriver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");
//Identify login button and click on login button
IWebElement loginButton = webDriver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();
//Check if user has logged in successfully
IWebElement hellohari = webDriver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if (hellohari.Text == "Hello hari!")
{ Console.WriteLine("Successfully logged in"); }
else { Console.WriteLine("not logged in"); }
