using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Equipment
    {
        public POS_Inv_Equipment()
        {
            this.POS_Inv_EquipmentByLocationHistory = new List<POS_Inv_EquipmentByLocationHistory>();
            this.POS_Inv_EquipsByOrder = new List<POS_Inv_EquipsByOrder>();
            this.POS_Inv_Parts = new List<POS_Inv_Parts>();
            this.POS_Inv_Applications = new List<POS_Inv_Applications>();
        }

        public int equipmentID { get; set; }
        public string eqName { get; set; }
        public Nullable<short> eqKind { get; set; }
        public Nullable<short> eqSerialNumLen { get; set; }
        public Nullable<bool> eqLeadingZeroes { get; set; }
        public Nullable<double> eqWeight { get; set; }
        public Nullable<decimal> eqCost { get; set; }
        public Nullable<decimal> eqPrice { get; set; }
        public string Item_FK { get; set; }
        public Nullable<bool> eqSerialNumberHasLetters { get; set; }
        public virtual ICollection<POS_Inv_EquipmentByLocationHistory> POS_Inv_EquipmentByLocationHistory { get; set; }
        public virtual ICollection<POS_Inv_EquipsByOrder> POS_Inv_EquipsByOrder { get; set; }
        public virtual ICollection<POS_Inv_Parts> POS_Inv_Parts { get; set; }
        public virtual ICollection<POS_Inv_Applications> POS_Inv_Applications { get; set; }
    }
}
