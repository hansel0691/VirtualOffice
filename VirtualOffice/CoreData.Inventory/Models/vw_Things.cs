using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Things
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<int> StockAmount { get; set; }
        public Nullable<int> ReservedAmount { get; set; }
        public Nullable<int> MinimumAmount { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Measure { get; set; }
    }
}
