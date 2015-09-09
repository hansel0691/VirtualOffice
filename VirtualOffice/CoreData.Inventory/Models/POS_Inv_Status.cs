using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Status
    {
        public int statusID { get; set; }
        public string staCategory { get; set; }
        public string staDescription { get; set; }
        public Nullable<int> staValue { get; set; }
    }
}
