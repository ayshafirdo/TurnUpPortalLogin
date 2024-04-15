using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalLogin.Utilities;

namespace TurnUpPortalLogin.Pages
{
    public class TimeandMaterial
    {
        private readonly By createNewLocator = By.XPath("//*[@id=\"container\"]/p/a");
        IWebElement createNew;
        private readonly By TypeCodeLocator = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]");
        IWebElement TypeCode;

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
            codeTextbox.SendKeys("ICTEST2024");
            IWebElement descriptionTextbox = webDriver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextbox.SendKeys("In this project we are going to create time record");
            
         
           
            IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id = \"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("200.00");
            
            //Click on Save button
            IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton")); saveButton.Click();
            Thread.Sleep(2000);
            IWebElement lastpageButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            lastpageButton.Click();
            


        }
        public void VerifyNewlyCreatedTimeRecord(IWebDriver webDriver)
        {
            //Verify newly created record on the last page
            Thread.Sleep(3000);

            IWebElement newTypeCode = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newTypeCode.Text == "ICTEST2024")
            {
                Console.WriteLine("New Type Code is created successfully");
            }
            else
            {
                Console.WriteLine("New Type Code is NOT created successfully");
            }
        }
        public void EditNewTimeRecord(IWebDriver webDriver)
        {
            //Edit the newly created type code
            Thread.Sleep(1000);
            IWebElement editButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);
            IWebElement TypeCodeEdit = webDriver.FindElement(By.XPath("/html/body/div[4]/form/div/div[2]/div/input"));
            TypeCodeEdit.Clear();
            TypeCodeEdit.SendKeys("ICTESTNEW");
            Thread.Sleep(1000);
            IWebElement saveButtonEdit = webDriver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveButtonEdit.Click();
        }
        public void VerifyEditedTimeRecord(IWebDriver webDriver)
        {
            Thread.Sleep(3000);
            IWebElement lastpageButtonAgain = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            lastpageButtonAgain.Click();

            //Verify edited type code from last page
            IWebElement editTypeCode = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
            if (editTypeCode.Text == "ICTESTNEW")
            {
                Console.WriteLine(" Type Code is edited successfully");
            }
            else
            {
                Console.WriteLine("Type Code is NOT edited successfully");
            }
        }
        public void DeleteTimeRecord(IWebDriver webDriver) 
        {
            //Delete the type code
            IWebElement deleteButton = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
        }
        public void VerifyDeleteTimeRecord(IWebDriver webDriver)
        {
            Thread.Sleep(3000);
            webDriver.SwitchTo().Alert().Accept();
            try
            {
                IWebElement editTypeCodeD = webDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[4]"));

                Console.WriteLine(" Type Code is deleted");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Type Code is not deleted");
            }
        }
        
    }
}
