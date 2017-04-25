using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("Modified Group");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            GroupData oldGroupData = oldGroups[0];

            app.Groups.Modify(0, newGroupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[0].Name = newGroupData.Name;
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
