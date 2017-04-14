using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : TestBase
    {
      
        [Test]
        public void EntryCreationTest()
        {
            
            EntryData entry = new EntryData("irene", "devyatova");
            entry.Address = "";
            entry.Address2 = "";
            entry.Company = "";
            entry.Email = "";
            entry.Email2 = "";
            entry.Email3 = "";
            entry.Fax = "";
            entry.Home = "";
            entry.Homepage = "";
            entry.Middlename = "";
            entry.Mobile = "";
            entry.Nickname = "";
            entry.Notes = "";
            entry.Phone2 = "";
            entry.Title = "";
            entry.Work = "";
            entry.BDay = "";
            entry.BMonth = "-";
            entry.BYear = "";
            entry.ADay = "";
            entry.AMonth = "-";
            entry.AYear = "";
          //  entry.EntryGroup = "";

            app.Entries.Create(entry);
        }

        [Test]
        public void EmptyEntryCreationTest()
        {
            EntryData entry = new EntryData("", "");
            entry.Address = "";
            entry.Address2 = "";
            entry.Company = "";
            entry.Email = "";
            entry.Email2 = "";
            entry.Email3 = "";
            entry.Fax = "";
            entry.Home = "";
            entry.Homepage = "";
            entry.Middlename = "";
            entry.Mobile = "";
            entry.Nickname = "";
            entry.Notes = "";
            entry.Phone2 = "";
            entry.Title = "";
            entry.Work = "";
            entry.BDay = "";
            entry.BMonth = "-";
            entry.BYear = "";
            entry.ADay = "";
            entry.AMonth = "-";
            entry.AYear = "";
           // entry.EntryGroup = "";

            app.Entries.Create(entry);
        }

        [Test]
        public void FilledInFormEntryCreationTest()
        {
            EntryData entry = new EntryData("test", "user");
            entry.Address = "asdasdaddress";
            entry.Address2 = "asdasdaddress2";
            entry.Company = "qweqwecompany";
            entry.Email = "asdtest@mail.com";
            entry.Email2 = "fghtest2@mail.com";
            entry.Email3 = "fghtest3@mail.com";
            entry.Fax = "0001 2312 31";
            entry.Home = "home, sweet home";
            entry.Homepage = "www.myhomepage.com";
            entry.Middlename = "J-J.";
            entry.Mobile = "113 123456 123";
            entry.Nickname = "my nickname";
            entry.Notes = "some notes are here";
            entry.Phone2 = "78970 77678 87";
            entry.Title = "my title";
            entry.Work = "my work";
            entry.BDay = "12";
            entry.BMonth = "July";
            entry.BYear = "1987";
            entry.ADay = "6";
            entry.AMonth = "October";
            entry.AYear = "2011";
          //  entry.EntryGroup = "q";

            app.Entries.Create(entry);
        }
        


    }
}

