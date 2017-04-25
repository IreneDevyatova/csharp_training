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

            Assert.AreEqual(oldEntries.Count - 1, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = app.Entries.GetEntriesList();

            EntryData entryToBeRemoved = oldEntries[0];
            oldEntries.RemoveAt(0);
            Assert.AreEqual(oldEntries, newEntries);

            foreach(EntryData entry in newEntries)
            {
                Assert.AreNotEqual(entry.Id, entryToBeRemoved.Id);
            }
        }

        [Test]
        public void EntryRemovalFromEditTest()
        {
            List<EntryData> oldEntries = app.Entries.GetEntriesList();
            

            app.Entries.RemoveEntryFromEdit(0);
            Assert.AreEqual(oldEntries.Count - 1, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = app.Entries.GetEntriesList();

            EntryData entryToBeRemoved = oldEntries[0];
            oldEntries.RemoveAt(0);
            Assert.AreEqual(oldEntries, newEntries);

            foreach (EntryData entry in newEntries)
            {
                Assert.AreNotEqual(entry.Id, entryToBeRemoved.Id);
            }
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
