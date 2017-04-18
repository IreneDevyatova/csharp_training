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
            Type(By.Name("firstname"), entry.Firstname);
            Type(By.Name("lastname"), entry.Lastname);
            Type(By.Name("middlename"), entry.Middlename);
            Type(By.Name("nickname"), entry.Nickname);
            Type(By.Name("title"), entry.Title);
            Type(By.Name("company"), entry.Company);
            Type(By.Name("address"), entry.Address);
            Type(By.Name("home"), entry.Home);
            Type(By.Name("mobile"), entry.Mobile);
            Type(By.Name("work"), entry.Work);
            Type(By.Name("fax"), entry.Fax);
            Type(By.Name("email"), entry.Email);
            Type(By.Name("email2"), entry.Email2);
            Type(By.Name("email3"), entry.Email3);
            Type(By.Name("homepage"), entry.Homepage);
            Type(By.Name("address2"), entry.Address2);
            Type(By.Name("phone2"), entry.Phone2);
            Type(By.Name("notes"), entry.Notes);
            Type(By.Name("byear"), entry.BYear);
            Type(By.Name("ayear"), entry.AYear);



            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(entry.BDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(entry.BMonth);
           
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
