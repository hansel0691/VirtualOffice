using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Purchases
    {
        public int purchaseID { get; set; }
        public Nullable<int> thingID { get; set; }
        public Nullable<int> providerID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> psAmount { get; set; }
        public Nullable<decimal> psCost { get; set; }
        public Nullable<System.DateTime> psDate { get; set; }
        public virtual POS_Inv_Providers POS_Inv_Providers { get; set; }
        public virtual POS_Inv_Things POS_Inv_Things { get; set; }
    }
}
