using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        private List<GroupData> groupCache = null;

       

        public List<GroupData> GetGroupsList()
        {
            if(groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillInGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newGroupData)
        {
            manager.Navigator.GoToGroupsPage();
           
            if (GroupExists())
            {
                SelectGroup(v);
                InitGroupModification();
                FillInGroupForm(newGroupData);
                SubmitGroupModification();
                ReturnToGroupsPage();
            }
            else
            {
                manager.Navigator.GoToGroupsPage();
                InitGroupCreation();
                FillInGroupForm(newGroupData);
                SubmitGroupCreation();
                ReturnToGroupsPage();

                SelectGroup(v);
                InitGroupModification();
                FillInGroupForm(newGroupData);
                SubmitGroupModification();
                ReturnToGroupsPage();
            }

            return this;
        }

        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper CreateNewGroup(GroupData newGroup)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillInGroupForm(newGroup);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
                manager.Navigator.GoToGroupsPage();
            
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupsPage();
            
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;

        }

        public GroupHelper ModifyGroup(GroupData group, GroupData newGroupData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            InitGroupModification();
            FillInGroupForm(newGroupData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper RemoveSelectedGroups(int v, int i)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(v);
            SelectGroup(i);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillInGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;

        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

     

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this; ;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this; ;
        }

        public bool GroupExists()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
