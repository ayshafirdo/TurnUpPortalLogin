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
//Navigate to Administration and click on it
IWebElement administrationDropdown = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdown.Click();
//Select Time and Material
IWebElement tmOption = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();
//Click on Create New button
IWebElement createNew = webDriver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNew.Click();
//Choose Time Type Code
IWebElement TypeCode = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
TypeCode.Click();
IWebElement timeType = webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
timeType.Click();
//Enter Code,Description and Price per unit
IWebElement codeTextbox = webDriver.FindElement(By.XPath("//*[@id=\"Code\"]"));
codeTextbox.SendKeys("ICTEST2024");
IWebElement descriptionTextbox = webDriver.FindElement(By.XPath("//*[@id=\"Description\"]"));
descriptionTextbox.SendKeys("In this project we are going to create time record");
IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id = \"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("200.00");
//Click on Save button
IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton"));saveButton.Click();
//Verify newly created record on the last page
Thread.Sleep(3000);
IWebElement lastpageButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
lastpageButton.Click();
IWebElement newTypeCode = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
if (newTypeCode.Text == "ICTEST2024")
{
    Console.WriteLine("New Type Code is created successfully");
}
else
{
    Console.WriteLine("New Type Code is NOT created successfully");
}


//Edit the newly created type code
IWebElement editButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();
Thread.Sleep(3000);
IWebElement TypeCodeEdit = webDriver.FindElement(By.XPath("/html/body/div[4]/form/div/div[2]/div/input"));
TypeCodeEdit.Clear();
TypeCodeEdit.SendKeys("ICTESTNEW");
Thread.Sleep(1000);
IWebElement saveButtonEdit = webDriver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")); 
saveButtonEdit.Click();
Thread.Sleep(3000);
IWebElement lastpageButtonAgain = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
lastpageButtonAgain.Click();

//Verify newly created type code from last page
IWebElement editTypeCode = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
if (editTypeCode.Text == "ICTESTNEW")
{
    Console.WriteLine(" Type Code is edited successfully");
}
else
{
    Console.WriteLine("Type Code is NOT edited successfully");
}


//Delete the type code
IWebElement deleteButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr/td[5]/a[2]"));
deleteButton.Click();




