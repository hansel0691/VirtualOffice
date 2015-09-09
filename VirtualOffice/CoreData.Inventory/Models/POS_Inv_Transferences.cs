using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Transferences
    {
        public int movementID { get; set; }
        public Nullable<int> SourceMerchID { get; set; }
        public Nullable<int> TargetMerchID { get; set; }
        public virtual POS_Inv_Movements POS_Inv_Movements { get; set; }
    }
}
