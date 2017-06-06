using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
    public class AddingEntryToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingEntryToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<EntryData> oldList = group.GetEntries();
            EntryData entry = EntryData.GetAll().Except(oldList).First();

            app.Entries.AddEntryToGroup(entry, group);

            List<EntryData> newList = group.GetEntries();
            oldList.Add(entry);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
