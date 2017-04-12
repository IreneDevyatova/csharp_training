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
            
            EntryData entry = new EntryData("irene", "devyatova");
            app.Entries.Create(entry);
        }

        [Test]
        public void EmptyEntryCreationTest()
        {
            EntryData entry = new EntryData("", "");
            app.Entries.Create(entry);
        }
    }
}

