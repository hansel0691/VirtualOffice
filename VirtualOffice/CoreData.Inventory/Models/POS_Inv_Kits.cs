using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Kits
    {
        public int KitID { get; set; }
        public string KitName { get; set; }
        public string KitDescription { get; set; }
        public Nullable<int> maxQtyShipFree { get; set; }
        public Nullable<decimal> KitPrice { get; set; }
        public Nullable<byte> KitType { get; set; }
        public Nullable<int> amount_measureID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
