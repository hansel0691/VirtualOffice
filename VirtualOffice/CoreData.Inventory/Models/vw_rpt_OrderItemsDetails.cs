using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_rpt_OrderItemsDetails
    {
        public int OrderID { get; set; }
        public string EquipmentName { get; set; }
        public string ItemSerialNumber { get; set; }
        public string TerminalID { get; set; }
    }
}
