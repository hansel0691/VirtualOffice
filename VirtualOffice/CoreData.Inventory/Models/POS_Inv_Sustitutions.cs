using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Sustitutions
    {
        public int movementID { get; set; }
        public Nullable<int> SourceLocID { get; set; }
        public Nullable<int> TargetMerchID { get; set; }
        public virtual POS_Inv_Locations POS_Inv_Locations { get; set; }
        public virtual POS_Inv_Movements POS_Inv_Movements { get; set; }
    }
}
