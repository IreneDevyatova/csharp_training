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
            manager.Navigator.GoToHomePage();
            SelectEntry(v);
            InitEntryModificationByIcon(v);
            FillInEntryForm(newEntryData);
            SubmitEntryModification();
            ReturnToHomePage();

            return this;
        }

        public EntryHelper ModifyFromViewPage(int v, EntryData newEntryData)
        {
            manager.Navigator.GoToHomePage();

            InitEntryModificationFromViewPage(v);
            FillInEntryForm(newEntryData);
            SubmitEntryModification();
            ReturnToHomePage();

            return this;
        }

        public EntryHelper RemoveFromList(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectEntry(v);
            RemoveEntryFromList();

            return this;
        }

        public EntryHelper RemoveEntryFromEdit(int v)
        {
            manager.Navigator.GoToHomePage();
            InitEntryModificationByIcon(v);
            RemoveEntryFromEdit();

            return this;
        }

        public EntryHelper RemoveAllEntries()
        {
            manager.Navigator.GoToHomePage();
            SelectAll();
            RemoveEntryFromList();
            return this;
        }
     
        public EntryHelper FillInEntryForm(EntryData entry)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entry.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entry.Lastname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(entry.Middlename);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(entry.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(entry.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(entry.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(entry.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(entry.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(entry.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(entry.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(entry.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(entry.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(entry.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(entry.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(entry.Homepage);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(entry.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(entry.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(entry.Notes);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(entry.BDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(entry.BMonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(entry.BYear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(entry.ADay);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(entry.AMonth);
           // new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(entry.EntryGroup);

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

        public EntryHelper SelectEntry(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public EntryHelper InitEntryModificationByIcon(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" +index + "]")).Click();
            return this;
        }

        public EntryHelper SubmitEntryModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public EntryHelper InitEntryModificationFromViewPage(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])["+ index +"]")).Click();
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public EntryHelper RemoveEntryFromList()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

          public EntryHelper RemoveEntryFromEdit()
        {
           
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public EntryHelper SelectAll()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }
    }
}
