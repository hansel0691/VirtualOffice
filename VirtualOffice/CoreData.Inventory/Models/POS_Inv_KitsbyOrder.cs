using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_KitsbyOrder
    {
        public int OrderID { get; set; }
        public int KitId { get; set; }
        public Nullable<decimal> okQuantity { get; set; }
        public Nullable<decimal> okPrice { get; set; }
        public Nullable<decimal> okDiscount { get; set; }
        public Nullable<decimal> okTax { get; set; }
        public Nullable<int> measureID { get; set; }
        public Nullable<decimal> okCost { get; set; }
    }
}
