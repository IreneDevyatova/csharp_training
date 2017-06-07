using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
    public class EntryHelper : HelperBase
    {
        public EntryHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        private List<EntryData> entryCache = null;

        public List<EntryData> GetEntriesList()
        {
            if(entryCache == null)
            {
                entryCache = new List<EntryData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.CssSelector("td"));
                    entryCache.Add(new EntryData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.XPath("(.//input[@name='selected[]'])")).GetAttribute("value")
                    });
                }
            }

            return new List<EntryData>(entryCache);
        }

        public int GetEntriesCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        public void AddEntryToGroup(EntryData entry, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectEntryToAdd(entry.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingEntryToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveEntryFromGroup(EntryData entry, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectGroupFromFilter();
            CommitEntryRemovalFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectGroupFromFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(GroupData.GetAll()[0].Name);
        }

        private void SelectEntryToAdd(string entryId)
        {
            driver.FindElement(By.Id(entryId)).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void CommitAddingEntryToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void CommitEntryRemovalFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }
        
        public EntryHelper Create(EntryData entry)
        {
            manager.Navigator.GoToCreateEntryPage();
            FillInEntryForm(entry);
            SubmitEntryCreation();
            ReturnToHomePage();
            return this;
        }

        public EntryHelper ModifyEntry(EntryData entry, EntryData newEntryData)
        {
            manager.Navigator.GoToHomePage();
            SelectEntry(entry.Id);
            InitEntryModification(entry.Id);
            FillInEntryForm(newEntryData);
            SubmitEntryModification();
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
            entryCache = null;

            return this;
        }

        public EntryHelper RemoveEntryFromEdit(int v)
        {
            manager.Navigator.GoToHomePage();
            InitEntryModificationByIcon(v);
            RemoveEntryFromEdit();
            entryCache = null;

            return this;
        }

        public EntryHelper RemoveAllEntries()
        {
            manager.Navigator.GoToHomePage();
            SelectAll();
            RemoveEntryFromList();
            entryCache = null;

            return this;
        }

        public EntryHelper RemoveFromList(EntryData entry)
        {
            SelectEntry(entry.Id);
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

            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(entry.BDay);
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(entry.BMonth);
           
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(entry.ADay);
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(entry.AMonth);

            return this;
        }

        public EntryHelper SubmitEntryCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            entryCache = null;
            return this;
        }

        public EntryHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public EntryHelper SelectEntry(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public EntryHelper InitEntryModificationByIcon(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public EntryHelper InitEntryModification(string id)
        {
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                string s = element.FindElement(By.Name("selected[]")).GetAttribute("Value");
                if (s == id)
                {
                    element.FindElement(By.XPath("(.//img[@title='Edit'])")).Click();
                }
            }

            return this;
        }

        public EntryHelper SubmitEntryModification()
        {
            driver.FindElement(By.Name("update")).Click();
            entryCache = null;
            return this;
        }

        public EntryHelper InitEntryModificationFromViewPage(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])["+ (index+1) +"]")).Click();
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public EntryHelper RemoveEntryFromList()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            entryCache = null;
            return this;
        }

          public EntryHelper RemoveEntryFromEdit()
        {
           
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            entryCache = null;

            return this;
        }

        public EntryHelper SelectEntry(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).Click();
            return this;
        }

        public EntryHelper SelectAll()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public EntryData GetEntryInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new EntryData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        public EntryData GetEntryInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitEntryModificationByIcon(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new EntryData(firstname, lastname)
            {
                Address = address,
                Home = home,
                Mobile = mobile,
                Work = work,
                Phone2 = phone2,
                Email = email,
                Email2 = email2,
                Email3 = email3

            };
        }

        public string GetEntryInfoFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitEntryModificationByIcon(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            if (!string.IsNullOrEmpty(home)) home = "H:" + home;

            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            if (!string.IsNullOrEmpty(mobile)) mobile = "M:" + mobile;

            string work = driver.FindElement(By.Name("work")).GetAttribute("value");
            if (!string.IsNullOrEmpty(work)) work = "W:" + work;

            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            if (!string.IsNullOrEmpty(fax)) fax = "F:" + fax;

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            if (!string.IsNullOrEmpty(homepage)) homepage = "Homepage:" + homepage;

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");

            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            if (!string.IsNullOrEmpty(phone2)) phone2 = "P:" + phone2;

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string editFormData = (firstname + middlename + lastname + nickname + title + company 
                + address + home + mobile + work + fax + email + email2 + email3 + homepage + address2 + phone2 + notes).Replace(" ", "");
            
            return editFormData;
        }

        public string GetEntryInfoFromViewForm(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenViewEntryForm(0);
            string content = driver.FindElement(By.Id("content")).Text.Replace("\r\n", "").Replace(" ", "");
            return content;
        }

        public EntryHelper OpenViewEntryForm(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void CheckEntryExists()
        {
            if (EntryExists() != true)
            {
                EntryData entryToAdd = new EntryData("first", "last");
                manager.Entries.Create(entryToAdd);
            }
        }

        public bool EntryExists()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
