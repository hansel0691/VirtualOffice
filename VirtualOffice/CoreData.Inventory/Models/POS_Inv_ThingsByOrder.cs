using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_ThingsByOrder
    {
        public int orderID { get; set; }
        public int thingID { get; set; }
        public Nullable<int> otQty { get; set; }
        public Nullable<decimal> otPrice { get; set; }
        public Nullable<decimal> otDiscount { get; set; }
        public Nullable<decimal> otTax { get; set; }
        public Nullable<int> otUnit { get; set; }
        public virtual POS_Inv_Things POS_Inv_Things { get; set; }
    }
}
