using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";
        private string group_parent_id = "";

        public GroupData(string name)
        {
            this.name = name;
        }


        public string Name

        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        public string GroupParentId
        {
            get
            {
                return group_parent_id;
            }
            set
            {
                group_parent_id = value;
            }
        }
    }
}
