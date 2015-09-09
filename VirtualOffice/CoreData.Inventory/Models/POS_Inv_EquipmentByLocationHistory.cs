using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_EquipmentByLocationHistory
    {
        public int locationhistoryID { get; set; }
        public int equipmentID { get; set; }
        public Nullable<int> leAmount { get; set; }
        public virtual POS_Inv_Equipment POS_Inv_Equipment { get; set; }
        public virtual POS_Inv_LocationHistory POS_Inv_LocationHistory { get; set; }
    }
}
