using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_ThingsByProvider
    {
        public int providerID { get; set; }
        public int thingID { get; set; }
        public Nullable<decimal> ptLastPrice { get; set; }
        public Nullable<System.DateTime> ptLastPurchaseDate { get; set; }
        public virtual POS_Inv_Providers POS_Inv_Providers { get; set; }
        public virtual POS_Inv_Things POS_Inv_Things { get; set; }
    }
}
