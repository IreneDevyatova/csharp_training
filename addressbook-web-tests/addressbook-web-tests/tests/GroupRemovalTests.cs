using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

        //[Test]
        //public void GroupsRemovalTest()
        //{
        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups.RemoveSelectedGroups(0, 1);

        //    List<GroupData> newGroups = app.Groups.GetGroupsList();

        //    oldGroups.RemoveRange(0, 1);
        //    Assert.AreEqual(oldGroups, newGroups);
        //}
    }
}
