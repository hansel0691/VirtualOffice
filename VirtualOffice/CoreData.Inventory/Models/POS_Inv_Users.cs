using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Users
    {
        public int userID { get; set; }
        public string usFirstName { get; set; }
        public string usLastName { get; set; }
        public string usNick { get; set; }
        public string usCreatedBy { get; set; }
        public Nullable<byte> usPrivilege { get; set; }
    }
}
