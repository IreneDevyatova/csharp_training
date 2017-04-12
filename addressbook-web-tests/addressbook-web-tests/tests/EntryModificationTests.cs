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
            newEntryData.Address = "asdasdaddress";
            newEntryData.Address2 = "asdasdaddress2";
            newEntryData.Company = "qweqwecompany";
            newEntryData.Email = "asdtest@mail.com";
            newEntryData.Email2 = "fghtest2@mail.com";
            newEntryData.Email3 = "fghtest3@mail.com";
            newEntryData.Fax = "0001 2312 31";
            newEntryData.Home = "home, sweet home";
            newEntryData.Homepage = "www.myhomepage.com";
            newEntryData.Middlename = "J-J.";
            newEntryData.Mobile = "113 123456 123";
            newEntryData.Nickname = "my nickname";
            newEntryData.Notes = "some notes are here";
            newEntryData.Phone2 = "78970 77678 87";
            newEntryData.Title = "my title";
            newEntryData.Work = "my work";
            newEntryData.BDay = "18";
            newEntryData.BMonth = "January";
            newEntryData.BYear = "2000";

            app.Entries.ModifyByIcon(3, newEntryData);
        }

        [Test]
        public void EntryModificationTestFromViewPage()
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

            app.Entries.ModifyFromViewPage(2, newEntryData);
        }
    }
}
