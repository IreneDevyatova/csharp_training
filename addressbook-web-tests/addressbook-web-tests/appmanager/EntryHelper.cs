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
        public EntryHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

      

        public EntryHelper Create(EntryData entry)
        {
            manager.Navigator.GoToCreateEntryPage();
            FillInEntryForm(entry);
            SubmitEntryCreation();
            ReturnToHomePage();
            return this;
        }

        public EntryHelper ModifyByIcon(int v, EntryData newEntryData)
        {
            //SelectEntry(v);
            manager.Navigator.GoToHomePage();
            InitEntryModificationByIcon();
            FillInEntryForm(newEntryData);
            SubmitEntryModification();
            ReturnToHomePage();

            return this;
        }

        public EntryHelper ModifyFromViewPage(int v, EntryData newEntryData)
        {
            manager.Navigator.GoToHomePage();
            InitEntryModificationFromViewPage();
            FillInEntryForm(newEntryData);
            SubmitEntryModification();
            ReturnToHomePage();

            return this;
        }

        public EntryHelper RemoveFromList(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectEntry(v);
            RemoveEntry();

            return this;
        }

      

        public EntryHelper FillInEntryForm(EntryData entry)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entry.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entry.Lastname);
            return this;
        }

        public EntryHelper SubmitEntryCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public EntryHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public EntryHelper SelectEntry(int v)
        {
            
            return this;
        }

        public EntryHelper InitEntryModificationByIcon()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public EntryHelper SubmitEntryModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public EntryHelper InitEntryModificationFromViewPage()
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[+ index +]")).Click();
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public EntryHelper RemoveEntry()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
