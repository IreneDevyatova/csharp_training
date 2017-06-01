using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : AuthTestBase
    {

           public static IEnumerable<EntryData> RandomEntryDataProvider()
           { 

                List<EntryData> entries = new List<EntryData>();
                for (int i = 0; i < 5; i++)
                {
                entries.Add(new EntryData(GenerateRandomString(30), GenerateRandomString(30)));
                }

                return entries;
           }
       
    

        [Test, TestCaseSource("RandomEntryDataProvider")]

        public void EntryCreationTest(EntryData entry)
        {
            List<EntryData> oldEntries = app.Entries.GetEntriesList();

            app.Entries.Create(entry);
            Assert.AreEqual(oldEntries.Count + 1, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = app.Entries.GetEntriesList();
            oldEntries.Add(entry);
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
        }
    }
}

