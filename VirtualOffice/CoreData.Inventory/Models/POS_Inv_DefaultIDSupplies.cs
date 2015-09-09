using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_DefaultIDSupplies
    {
        public int applicationID { get; set; }
        public int packageID { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}
