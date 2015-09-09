using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_PackageByOrderbck2007
    {
        public int orderID { get; set; }
        public int packageID { get; set; }
        public Nullable<decimal> opQuantity { get; set; }
        public Nullable<decimal> opPrice { get; set; }
        public Nullable<decimal> opDiscount { get; set; }
        public Nullable<decimal> opTax { get; set; }
        public Nullable<int> measureID { get; set; }
        public Nullable<decimal> opCost { get; set; }
        public string product_sbt { get; set; }
    }
}
