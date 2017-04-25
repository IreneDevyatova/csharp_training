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

            app.Groups.Modify(0, newGroupData);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
