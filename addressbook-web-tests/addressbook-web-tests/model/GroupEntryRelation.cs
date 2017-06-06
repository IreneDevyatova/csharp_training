﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupEntryRelation
    {
        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        [Column(Name = "id")]
        public string EntryId { get; set; }
    }
}
