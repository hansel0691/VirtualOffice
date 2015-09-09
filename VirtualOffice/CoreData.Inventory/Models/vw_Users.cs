using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Users
    {
        public int userID { get; set; }
        public string usFirstName { get; set; }
        public string usLastName { get; set; }
        public string usNick { get; set; }
    }
}
