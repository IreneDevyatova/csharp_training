using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class EntryRemovalFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveEntryFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<EntryData> oldList = group.GetEntries();
            EntryData entry = oldList.First();

            app.Entries.RemoveEntryFromGroup(entry, group);

            List<EntryData> newList = group.GetEntries();
            oldList.Remove(entry);
            oldList.Sort();
            newList.Sort();

            Assert.AreNotEqual(oldList, newList);
        }
    }
}
