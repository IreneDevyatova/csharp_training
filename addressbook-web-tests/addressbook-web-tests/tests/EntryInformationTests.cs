using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class EntryInformationTests : AuthTestBase
    {
        [Test]
        public void TestEntryInformation()
        {
            EntryData fromTable = app.Entries.GetEntryInformationFromTable(0);
            EntryData fromForm = app.Entries.GetEntryInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
        [Test]
        public void TestEntryInformationFromView()
        {
            string fromEditForm = app.Entries.GetEntryInfoFromEditForm(0);
            string fromViewForm = app.Entries.GetEntryInfoFromViewForm(0);
            
            Assert.AreEqual(fromEditForm, fromViewForm);
            
        }
    }
}
