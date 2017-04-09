using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class EntryHelper : HelperBase
    {
        public EntryHelper(IWebDriver driver) 
            : base(driver)
        {
        }

       

        public void FillInEntryForm(EntryData entry)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entry.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entry.Lastname);

        }

        public void SubmitEntryCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

    
    }
}
