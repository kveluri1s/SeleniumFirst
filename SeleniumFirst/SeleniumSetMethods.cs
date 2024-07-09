using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    public class SeleniumSetMethods
    {
        
        public static void typeText(IWebDriver dr , String elementType, String locator, String value)
        {
            if (elementType.ToLower() == "id")
                dr.FindElement(By.Id(locator)).SendKeys(value);
            else if (elementType.ToLower() == "name")
                dr.FindElement(By.Name(locator)).SendKeys(value);
            else if (elementType.ToLower() == "xpath")
                dr.FindElement(By.XPath(locator)).SendKeys(value);
            else
                throw new ElementNotVisibleException();
        }

        public static void clickElement(IWebDriver dr , String elementType, String locator)
        {
            if (elementType.ToLower() == "id")
                dr.FindElement(By.Id(locator)).Click();
            else if (elementType.ToLower() == "name")
                dr.FindElement(By.Name(locator)).Click();
            else if (elementType.ToLower() == "xpath")
                dr.FindElement(By.XPath(locator)).Click();
            else
                throw new ElementClickInterceptedException();
            
             
        }

        public static void ActionsclickElement(IWebDriver dr, String elementType, String locator)
        {
            Actions actions = new Actions(dr);
            IJavaScriptExecutor ex = (IJavaScriptExecutor)dr;
            if (elementType.ToLower() == "id")
                  ex.ExecuteScript("arguments[0].click();", dr.FindElement(By.Id(locator)));
            else if (elementType.ToLower() == "name")
                  ex.ExecuteScript("arguments[0].click();", dr.FindElement(By.Name(locator)));
            else if (elementType.ToLower() == "xpath")          
                  ex.ExecuteScript("arguments[0].click();", dr.FindElement(By.XPath(locator)));
            else
                throw new ElementClickInterceptedException();


        }

        /*public static void SubmitForm(IWebDriver dr, String elementType, String locator)
        {
            try
            {
                if (elementType.ToLower() == "id")
                    dr.FindElement(By.Id(locator)).Submit();
                else if (elementType.ToLower() == "name")
                    dr.FindElement(By.Name(locator)).Submit();
                else if (elementType.ToLower() == "xpath")
                    dr.FindElement(By.XPath(locator)).Submit();
            }
            catch
            {
                throw new ElementClickInterceptedException();
            }

        }*/


        public static void SelectvaluesDropdown(IWebDriver dr , String elementType, String locator, String value)
        {

             if (elementType.ToLower() == "id")
                new SelectElement(dr.FindElement(By.Id(locator))).SelectByValue(value);
            else if (elementType.ToLower() == "name")
                new SelectElement(dr.FindElement(By.Name(locator))).SelectByValue(value);
            else if (elementType.ToLower() == "xpath")
                new SelectElement(dr.FindElement(By.XPath(locator))).SelectByValue(value);
            else
                throw new ElementClickInterceptedException();
        }

    }
}
