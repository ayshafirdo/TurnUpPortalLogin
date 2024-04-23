using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalLogin.Utilities;

namespace TurnUpPortalLogin.Pages
{
    public class TimeandMaterialPage
    {
        private readonly By createNewLocator = By.XPath("//*[@id=\"container\"]/p/a");
        IWebElement? createNew;
        private readonly By TypeCodeLocator = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]");
        IWebElement? TypeCode;

        public void CreateNewTimeRecord(IWebDriver webDriver)
        {

            //Click on Create New button
            createNew = webDriver.FindElement(createNewLocator);
            createNew.Click();
            //Choose Time Type Code
            Thread.Sleep(1000);
            TypeCode = webDriver.FindElement(TypeCodeLocator);
            TypeCode.Click();
            IWebElement timeType = webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
            timeType.Click();
            //Enter Code,Description and Price per unit
            IWebElement codeTextbox = webDriver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeTextbox.SendKeys("FIRSTIC");
            IWebElement descriptionTextbox = webDriver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextbox.SendKeys("In this project we are going to create time record");



            IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id = \"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("200.00");

            //Click on Save button
            IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton")); saveButton.Click();
            Thread.Sleep(2000);




        }
        public void VerifyNewlyCreatedTimeRecord(IWebDriver webDriver)
        {
            //Verify newly created record on the last page

            IWebElement lastpagebutton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = webDriver.FindElement(By.XPath("//li/span")).Text;
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = webDriver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = webDriver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "FIRSTIC")
                    {
                        Console.WriteLine("Created Record was found");
                        TestContext.Out.WriteLine("Record created");
                        break;
                    };






                }
                webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();

            }


        }
        public void EditNewTimeRecord(IWebDriver webDriver)
        {
            //Edit the newly created type code
            Thread.Sleep(5000);
            IWebElement lastpagebutton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = webDriver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            firstPageButton.Click();
            for (int i = 1; i <= Int32.Parse(tmLastPage); i++)
            {
                int tmRows = webDriver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = webDriver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "FIRSTIC")
                    {
                        Console.WriteLine("Created Record was found");
                        webDriver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[5]/a[1]")).Click(); Thread.Sleep(2000);
                        webDriver.FindElement(By.XPath("//input[@id='Code']")).Clear(); Thread.Sleep(1000);
                        webDriver.FindElement(By.XPath("//input[@id='Code']")).SendKeys("ICTESTNEWAGAIN");
                        webDriver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();
                        Thread.Sleep(1000);
                        break;

                    };

                }
                webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();









            }
        }
        public void VerifyEditedTimeRecord(IWebDriver webDriver)
        {
            Thread.Sleep(5000);
            IWebElement lastpagebutton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpagebutton.Click();
            string tmLastPage = webDriver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = webDriver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = webDriver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "ICTESTNEWAGAIN")
                    {
                        Console.WriteLine("Record is edited");

                        break;
                    };


                }
                webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();
            }
        }





        public void DeleteTimeRecord(IWebDriver webDriver)
        {
            IWebElement lastpageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpageButton.Click();
            Thread.Sleep(1000);
            string tmLastPage = webDriver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            firstPageButton.Click();
            Thread.Sleep(1000);
            for (int i = 1; i <= Int32.Parse(tmLastPage); i++)
            {
                int tmRows = webDriver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = webDriver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "ICTESTNEWAGAIN")
                    {
                        Console.WriteLine("Record to be deleted is found");
                        webDriver.FindElement(By.XPath("//tbody/tr[" + j + "]/td[5]/a[2]")).Click(); Thread.Sleep(2000);
                        webDriver.SwitchTo().Alert().Accept();
                        break;
                    };


                }
                webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();

            }
        }








        public void VerifyDeleteTimeRecord(IWebDriver webDriver)
        {
            IWebElement lastpageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            lastpageButton.Click();
            string tmLastPage = webDriver.FindElement(By.XPath("//li/span")).Text;
            IWebElement firstPageButton = webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the first')]"));
            for (int i = 1; i <= tmLastPage.Length; i++)
            {
                int tmRows = webDriver.FindElements(By.XPath("//tbody/tr")).Count();
                for (int j = 1; j <= tmRows; j++)
                {
                    IWebElement codeValue = webDriver.FindElement(By.XPath("//tr[" + j + "]/td[1]"));
                    if (codeValue.Text == "ICTESTNEWAGAIN")
                    {
                        Console.WriteLine("Record not deleted");
                        break;
                    };


                }
                webDriver.FindElement(By.XPath("//span[contains(text(),'Go to the next page')]")).Click();
                Console.WriteLine("Record is deleted");
            }
        }
    }
}







