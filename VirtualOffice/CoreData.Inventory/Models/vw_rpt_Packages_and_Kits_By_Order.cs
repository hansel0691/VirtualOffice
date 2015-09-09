using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_rpt_Packages_and_Kits_By_Order
    {
        public int OrderID { get; set; }
        public Nullable<int> ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Discount { get; set; }
    }
}
