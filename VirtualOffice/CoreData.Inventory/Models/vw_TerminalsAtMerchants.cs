using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_TerminalsAtMerchants
    {
        public string SerialNumber { get; set; }
        public int ID { get; set; }
        public Nullable<System.DateTime> InventoryDate { get; set; }
        public Nullable<System.DateTime> SoldDate { get; set; }
        public string HardwareRev { get; set; }
        public string TerminalID { get; set; }
        public int MID { get; set; }
        public string LocMerch { get; set; }
    }
}
