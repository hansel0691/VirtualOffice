using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Parts
    {
        public int partID { get; set; }
        public string ptDescription { get; set; }
        public Nullable<int> equipmentID { get; set; }
        public virtual POS_Inv_Equipment POS_Inv_Equipment { get; set; }
    }
}
