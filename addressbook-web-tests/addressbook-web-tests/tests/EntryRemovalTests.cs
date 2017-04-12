using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryRemovalTests : TestBase
    {
        [Test]
        public void EntryRemovalTestFromList()
        {

            app.Entries.RemoveFromList(4);

        }
    }
}
