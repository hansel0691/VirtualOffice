using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_PinpadsAtMerchants
    {
        public int itemID { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<System.DateTime> InventoryDate { get; set; }
        public Nullable<System.DateTime> SoldDate { get; set; }
        public string HardwareRev { get; set; }
        public string AssociatedTerminal { get; set; }
        public string LocMerch { get; set; }
    }
}
