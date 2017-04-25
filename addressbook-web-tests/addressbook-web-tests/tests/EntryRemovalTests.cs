using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryRemovalTests : AuthTestBase
    {
        [Test]
        public void EntryRemovalFromListTest()
        {
            List<EntryData> oldEntries = app.Entries.GetEntriesList();

            app.Entries.RemoveFromList(0);

            List<EntryData> newEntries = app.Entries.GetEntriesList();
            oldEntries.RemoveAt(0);
            Assert.AreEqual(oldEntries, newEntries);
        }

        [Test]
        public void EntryRemovalFromEditTest()
        {
            List<EntryData> oldEntries = app.Entries.GetEntriesList();

            app.Entries.RemoveEntryFromEdit(0);

            List<EntryData> newEntries = app.Entries.GetEntriesList();
            oldEntries.RemoveAt(0);
            Assert.AreEqual(oldEntries, newEntries);
        }
        //[Test]
        //public void AllEntriesRemovalTest()
        //{
        //    List<EntryData> oldEntries = app.Entries.GetEntriesList();

        //    app.Entries.RemoveAllEntries();

        //    List<EntryData> newEntries = app.Entries.GetEntriesList();
        //    oldEntries.RemoveAt(0);
        //    Assert.AreEqual(oldEntries, newEntries);
        //}
    }
}
