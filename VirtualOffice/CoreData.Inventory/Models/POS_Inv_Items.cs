using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Items
    {
        public POS_Inv_Items()
        {
            this.POS_Inv_EquipsByOrder = new List<POS_Inv_EquipsByOrder>();
            this.POS_Inv_Movements = new List<POS_Inv_Movements>();
            this.POS_Inv_Replacements = new List<POS_Inv_Replacements>();
            this.POS_Inv_Printers1 = new List<POS_Inv_Printers>();
        }

        public int itemID { get; set; }
        public string itSerialNumber { get; set; }
        public Nullable<System.DateTime> itInventoryDate { get; set; }
        public Nullable<int> locationID { get; set; }
        public Nullable<decimal> Merchant_FK { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<short> itStatus { get; set; }
        public Nullable<System.DateTime> itSoldDate { get; set; }
        public Nullable<short> itKind { get; set; }
        public Nullable<bool> itEmcrpypted { get; set; }
        public Nullable<int> rma { get; set; }
        public virtual ICollection<POS_Inv_EquipsByOrder> POS_Inv_EquipsByOrder { get; set; }
        public virtual POS_Inv_Locations POS_Inv_Locations { get; set; }
        public virtual ICollection<POS_Inv_Movements> POS_Inv_Movements { get; set; }
        public virtual ICollection<POS_Inv_Replacements> POS_Inv_Replacements { get; set; }
        public virtual POS_Inv_Printers POS_Inv_Printers { get; set; }
        public virtual ICollection<POS_Inv_Printers> POS_Inv_Printers1 { get; set; }
        public virtual POS_Inv_Terminals POS_Inv_Terminals { get; set; }
    }
}
