using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_EquipsByOrder
    {
        public int equipsbyorderID { get; set; }
        public int orderID { get; set; }
        public int equipmentID { get; set; }
        public Nullable<int> itemID { get; set; }
        public string TerminalID { get; set; }
        public Nullable<decimal> oeCost { get; set; }
        public Nullable<decimal> oePrice { get; set; }
        public virtual POS_Inv_Equipment POS_Inv_Equipment { get; set; }
        public virtual POS_Inv_Items POS_Inv_Items { get; set; }
    }
}
