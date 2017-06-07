using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            
            GroupData newGroupData = new GroupData("Modified Group");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            app.Groups.CheckGroupExists();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroupData = oldGroups[0];

            app.Groups.ModifyGroup(oldGroupData, newGroupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroupData.Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroupData.Id)
                {
                    Assert.AreEqual(newGroupData.Name, group.Name);
                }
            }
        }
    }
}
