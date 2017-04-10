using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class EntryModificationTests : TestBase
    {
        [Test]
        public void EntryModificationTestByIcon()
        {
            EntryData newEntryData = new EntryData("abyr", "abyr");
            app.Entries.ModifyByIcon(1, newEntryData);
        }

        [Test]
        public void EntryModificationTestFromViewPage()
        {
            EntryData newEntryData = new EntryData("abyr", "abyr");
            app.Entries.ModifyFromViewPage(2, newEntryData);
        }
    }
}
