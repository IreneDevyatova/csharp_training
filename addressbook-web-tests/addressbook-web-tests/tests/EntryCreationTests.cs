using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : EntryTestBase
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

        public static IEnumerable<EntryData> EntryDataFromXmlFile()
        {

            return (List<EntryData>)
                new XmlSerializer(typeof(List<EntryData>))
                .Deserialize(new StreamReader(@"entries.xml"));
        }

        public static IEnumerable<EntryData> EntryDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<EntryData>>(
                File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("EntryDataFromXmlFile")]

        public void EntryCreationTest(EntryData entry)
        {
            List<EntryData> oldEntries = EntryData.GetAll();

            app.Entries.Create(entry);
            Assert.AreEqual(oldEntries.Count + 1, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = EntryData.GetAll();
            oldEntries.Add(entry);
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);
        }

        //[Test]
        //public void TestDBConnectivityEntries()
        //{
        //    DateTime start = DateTime.Now;
        //    List<EntryData> fromUi = app.Entries.GetEntriesList();
        //    DateTime end = DateTime.Now;
        //    System.Console.Out.WriteLine(end.Subtract(start));

        //    start = DateTime.Now;
        //    List<EntryData> fromDb = EntryData.GetAll();
        //     end = DateTime.Now;
        //     System.Console.Out.WriteLine(end.Subtract(start));
        //  }
}
}

