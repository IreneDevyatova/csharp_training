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
            app.Entries.RemoveFromList(1);
        }

        [Test]
        public void EntryRemovalFromEditTest()
        {

            app.Entries.RemoveEntryFromEdit(1);
        }
        [Test]
        public void AllEntriesRemovalTest()
        {

            app.Entries.RemoveAllEntries();
        }
    }
}
