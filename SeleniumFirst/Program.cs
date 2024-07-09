using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;

namespace SeleniumFirst
{
    
    class Program
    {
        IWebDriver dr = new ChromeDriver();
        String agreebutton = "//button[contains(. ,'I agree')]";
        String textBox = "//span[contains(.,'Text Box')]";
        String username = "//input[@id='userName']";
        String userEmail = "//input[@id='userEmail']";
        String usercurrAddress = "//textarea[@id='currentAddress']";
        String userPermAddress = "//textarea[@id='permanentAddress']";
        String btnSubmit = "//button[@id='submit']";
        String txtcurrAdd = "//p[@id='currentAddress']";
        

        static void Main(String[] args)
        {

        }

        [SetUp]
        public void onlineFormLaunch()
        {
            dr.Navigate().GoToUrl("https://demoqa.com/elements");
            dr.Manage().Window.Maximize();
            if (dr.FindElements(By.XPath("//button[contains(. ,'I agree')]")).Count() > 0)
            {
                SeleniumSetMethods.clickElement(dr,"xpath", agreebutton);
            }
                          
            Console.WriteLine("Browser launched");            

        }
        
        [Test]       
        public void onlineFormSubmission()
        {
            
            if (dr.FindElement(By.XPath(textBox)).Displayed)
            {
                SeleniumSetMethods.clickElement(dr,"xpath", textBox);
                SeleniumSetMethods.typeText(dr, "xpath", username, "Ramkumar Krishnamurthy");
                SeleniumSetMethods.typeText(dr, "xpath", userEmail, "gkmram@gmail.com");
                SeleniumSetMethods.typeText(dr, "xpath", usercurrAddress , "123 Dowling Street");
                SeleniumSetMethods.typeText(dr, "xpath", userPermAddress, "123 Dowling Street");
                if (dr.FindElement(By.XPath(btnSubmit)).Displayed)
                {
                    SeleniumSetMethods.ActionsclickElement(dr, "xpath", btnSubmit);
                }
                    
                outputValidation();
                Console.WriteLine("Form filled and submitted successfully");
            }
            else
            {
                throw new NoSuchElementException();
            }

        }

        
        public void outputValidation()
        {

            if (dr.FindElement(By.XPath(btnSubmit)).Displayed)
            {
                String fulladdress = SeleniumGetMethods.GetText(dr,"xpath", txtcurrAdd);
                String[] address = fulladdress.Split(':');
                if(SeleniumGetMethods.TextValidation(dr,"123 Dowling Street",address[1]))
                {
                    Console.WriteLine("Form filled and submitted successfully");
                }
                else
                {
                    throw new AssertionException("current address not valid and hence failed.");
                }
            }
            else
            {
                throw new NoSuchElementException();
            }

        }

        [TearDown]
        public void cleanup()
        {
            dr.Quit();
            Console.WriteLine("Browser closed");
        }
    }
}
