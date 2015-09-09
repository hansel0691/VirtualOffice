using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Terminals
    {
        public int itemID { get; set; }
        public string tmID { get; set; }
        public string tmHardwareRev { get; set; }
        public virtual POS_Inv_Items POS_Inv_Items { get; set; }
    }
}
