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

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            GroupData groupToBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, groupToBeRemoved.Id);
            }
        }

        //[Test]
        //public void GroupsRemovalTest()
        //{
        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups.RemoveSelectedGroups(0, 1);

            //Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

        //    List<GroupData> newGroups = app.Groups.GetGroupsList();

        //    oldGroups.RemoveRange(0, 1);
        //    Assert.AreEqual(oldGroups, newGroups);
        //}
    }
}
