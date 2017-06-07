using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryRemovalTests : EntryTestBase
    {
        [Test]
        public void EntryRemovalFromListTest()
        {
            app.Entries.CheckEntryExists();

            List<EntryData> oldEntries = EntryData.GetAll();
            EntryData toBeRemoved = oldEntries[0];
            app.Entries.RemoveFromList(toBeRemoved);

            Assert.AreEqual(oldEntries.Count - 1, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = EntryData.GetAll();

            oldEntries.RemoveAt(0);
            Assert.AreEqual(oldEntries, newEntries);

            foreach(EntryData entry in newEntries)
            {
                Assert.AreNotEqual(entry.Id, toBeRemoved.Id);
            }
        }

        //[Test]
        //public void EntryRemovalFromEditTest()
        //{
        //    List<EntryData> oldEntries = app.Entries.GetEntriesList();
            

        //    app.Entries.RemoveEntryFromEdit(0);
        //    Assert.AreEqual(oldEntries.Count - 1, app.Entries.GetEntriesCount());

        //    List<EntryData> newEntries = app.Entries.GetEntriesList();

        //    EntryData entryToBeRemoved = oldEntries[0];
        //    oldEntries.RemoveAt(0);
        //    Assert.AreEqual(oldEntries, newEntries);

        //    foreach (EntryData entry in newEntries)
        //    {
        //        Assert.AreNotEqual(entry.Id, entryToBeRemoved.Id);
        //    }
        //}
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
