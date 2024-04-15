using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalLogin.Utilities
{
    public class WaitUtils
    {
        public static void WaitToBeVisible(IWebDriver webDriver,string tmOptionLocator,string locatorValue,int seconds)
        {
            WebDriverWait driverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(tmOptionLocator)));
        }
    }
}
