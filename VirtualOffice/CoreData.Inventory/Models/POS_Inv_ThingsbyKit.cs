using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_ThingsbyKit
    {
        public int KitID { get; set; }
        public int thingID { get; set; }
        public Nullable<decimal> tkQuantity { get; set; }
    }
}
