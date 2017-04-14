using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("Modified Group");
            newGroupData.Header = "Modified Header";
            newGroupData.Footer = "Modified Footer";
            newGroupData.GroupParentId = "Modified Group";
            app.Groups.Modify(1, newGroupData);
        }
    }
}
