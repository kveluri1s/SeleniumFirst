using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFirst
{
    class SeleniumGetMethods
    {
        public static String GetText(IWebDriver dr, String elementType, String locator)
        {
            String text;
            if (elementType.ToLower() == "id")
            {
                text = dr.FindElement(By.Id(locator)).Text;
            }

            else if (elementType.ToLower() == "name")
            {

                 text = dr.FindElement(By.Name(locator)).Text;
            }
            else if (elementType.ToLower() == "xpath")
            {
                 text = dr.FindElement(By.XPath(locator)).Text;
            }

            else
            {
                throw new ElementNotVisibleException();
            }
            return text;
        }

   


        public static Boolean GetTextAndValidate(IWebDriver dr, String elementType, String locator, String validationvalue)
        {
            bool validaton = false;
            if (elementType.ToLower() == "id")
            {
                String text = GetText(dr, "id", locator);
                if (text.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
                {
                    validaton = true;
                }
            }

            else if (elementType.ToLower() == "name")
            {

                String text = GetText(dr, "name", locator);
                if (text.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
                {
                    validaton = true;
                }
            }
            else if (elementType.ToLower() == "xpath")
            {
                String text = GetText(dr, "xpath", locator);
                if (text.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
                {
                    validaton = true;
                }
            }

            else
            {
                validaton = false;
                throw new ElementNotVisibleException();                
            }
            return validaton;
        }

        public static Boolean TextValidation(IWebDriver dr, String refValue ,  String validationvalue)
        {
            bool validaton = false;
           
                if (refValue.ToLower().Trim().Equals(validationvalue.ToLower().Trim()))
                {
                    validaton = true;
                }           
               else
                {
                    validaton = false;
                    throw new ElementNotVisibleException();
                }
                return validaton;
        }

    }

}
