﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GetAll();

            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
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
