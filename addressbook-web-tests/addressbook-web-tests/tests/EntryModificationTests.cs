using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class EntryModificationTests : AuthTestBase
    {
        [Test]
        public void EntryModificationByIconTest()
        {
            EntryData newEntryData = new EntryData("asdasdasd", "dhgfhdgfhdgf");
            
            newEntryData.Address = "asdasdaddress";
            newEntryData.Address2 = null;
            newEntryData.Company = "qweqwecompany";
            newEntryData.Email = "asdtest@mail.com";
            newEntryData.Email2 = "fghtest2@mail.com";
            newEntryData.Email3 = "fghtest3@mail.com";
            newEntryData.Fax = "0001 2312 31";
            newEntryData.Home = "home, sweet home";
            newEntryData.Homepage = "www.myhomepage.com";
            newEntryData.Middlename = "J-J.";
            newEntryData.Mobile = "113 123456 123";
            newEntryData.Nickname = null;
            newEntryData.Notes = "some notes are here";
            newEntryData.Phone2 = "78970 77678 87";
            newEntryData.Title = "my title";
            newEntryData.Work = "my work";
            newEntryData.BDay = "18";
            newEntryData.BMonth = "January";
            newEntryData.BYear = "2000";
            newEntryData.ADay = "13";
            newEntryData.AMonth = "March";
            newEntryData.AYear = "2011";

            List<EntryData> oldEntries = app.Entries.GetEntriesList();
            EntryData oldEntryData = oldEntries[0];

            app.Entries.ModifyByIcon(0, newEntryData);
            Assert.AreEqual(oldEntries.Count, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = app.Entries.GetEntriesList();
            oldEntries[0].Firstname = newEntryData.Firstname;
            oldEntries[0].Lastname = newEntryData.Lastname;
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);

            foreach (EntryData entry in newEntries)
            {
                if (entry.Id == oldEntryData.Id)
                {
                    Assert.AreEqual(newEntryData.Firstname, entry.Firstname);
                    Assert.AreEqual(newEntryData.Lastname, entry.Lastname);
                }
            }
        }

        [Test]
        public void EntryModificationFromViewPageTest()
        {
            EntryData newEntryData = new EntryData("asd", "qwe");
            
            newEntryData.Address = "address";
            newEntryData.Address2 = "address2";
            newEntryData.Company = "company";
            newEntryData.Email = "test@mail.com";
            newEntryData.Email2 = "test2@mail.com";
            newEntryData.Email3 = "test3@mail.com";
            newEntryData.Fax = "1231231";
            newEntryData.Home = "sweet home";
            newEntryData.Homepage = "www.homepage.com";
            newEntryData.Middlename = "J.";
            newEntryData.Mobile = "1131123123";
            newEntryData.Nickname = "nickname";
            newEntryData.Notes = "some notes";
            newEntryData.Phone2 = "789707787";
            newEntryData.Title = "title";
            newEntryData.Work = "work";
            newEntryData.BDay = "19";
            newEntryData.BMonth = "May";
            newEntryData.BYear = "1967";
            newEntryData.ADay = "30";
            newEntryData.AMonth = "November";
            newEntryData.AYear = "1999";

            List<EntryData> oldEntries = app.Entries.GetEntriesList();
            EntryData oldEntryData = oldEntries[0];


            app.Entries.ModifyFromViewPage(0, newEntryData);
            Assert.AreEqual(oldEntries.Count, app.Entries.GetEntriesCount());

            List<EntryData> newEntries = app.Entries.GetEntriesList();
            oldEntries[0].Firstname = newEntryData.Firstname;
            oldEntries[0].Lastname = newEntryData.Lastname;
            oldEntries.Sort();
            newEntries.Sort();
            Assert.AreEqual(oldEntries, newEntries);

            foreach (EntryData entry in newEntries)
            {
                if (entry.Id == oldEntryData.Id)
                {
                    Assert.AreEqual(newEntryData.Firstname, entry.Firstname);
                    Assert.AreEqual(newEntryData.Lastname, entry.Lastname); 
                }
            }
        }
    }
}
