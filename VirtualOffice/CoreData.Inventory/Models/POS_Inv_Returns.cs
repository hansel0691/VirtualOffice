using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Returns
    {
        public int movementID { get; set; }
        public Nullable<int> locationID { get; set; }
        public Nullable<int> merchant_FK { get; set; }
        public virtual POS_Inv_Locations POS_Inv_Locations { get; set; }
        public virtual POS_Inv_Movements POS_Inv_Movements { get; set; }
    }
}
