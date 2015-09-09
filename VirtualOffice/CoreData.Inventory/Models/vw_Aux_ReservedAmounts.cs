using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Aux_ReservedAmounts
    {
        public int orderID { get; set; }
        public Nullable<short> orType { get; set; }
        public Nullable<short> orStatus { get; set; }
        public int thingID { get; set; }
        public string thDescription { get; set; }
        public Nullable<int> thReservedAmount { get; set; }
        public Nullable<decimal> RealReserved { get; set; }
    }
}
