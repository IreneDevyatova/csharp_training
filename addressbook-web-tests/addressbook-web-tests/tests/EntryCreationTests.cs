using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : TestBase
    {
        

        [Test]
        public void EntryCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToCreateEntryPage();
            EntryData entry = new EntryData("irene", "devyatova");
            app.Entry.FillInEntryForm(entry);
            app.Entry.SubmitEntryCreation();
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            app.Navigator.ReturnToHomePage();
        }

     
        
    }
}

