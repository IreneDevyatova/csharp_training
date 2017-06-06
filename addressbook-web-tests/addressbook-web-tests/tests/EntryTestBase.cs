using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class EntryTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareEntriesUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<EntryData> fromUI = app.Entries.GetEntriesList();
                List<EntryData> fromDB = EntryData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
