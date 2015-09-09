using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_LocationHistory
    {
        public POS_Inv_LocationHistory()
        {
            this.POS_Inv_EquipmentByLocationHistory = new List<POS_Inv_EquipmentByLocationHistory>();
        }

        public int locationhistoryID { get; set; }
        public System.DateTime lhdate { get; set; }
        public int locationID { get; set; }
        public virtual ICollection<POS_Inv_EquipmentByLocationHistory> POS_Inv_EquipmentByLocationHistory { get; set; }
        public virtual POS_Inv_Locations POS_Inv_Locations { get; set; }
    }
}
