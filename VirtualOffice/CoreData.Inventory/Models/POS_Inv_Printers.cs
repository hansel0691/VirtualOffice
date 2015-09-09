using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Printers
    {
        public int itemID { get; set; }
        public string prHardwareRev { get; set; }
        public Nullable<int> prTerminalID { get; set; }
        public virtual POS_Inv_Items POS_Inv_Items { get; set; }
        public virtual POS_Inv_Items POS_Inv_Items1 { get; set; }
    }
}
