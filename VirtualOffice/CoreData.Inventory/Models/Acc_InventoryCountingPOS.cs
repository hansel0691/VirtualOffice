using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class Acc_InventoryCountingPOS
    {
        public int cnt_id { get; set; }
        public Nullable<int> cnt_locationid { get; set; }
        public Nullable<int> cnt_productid { get; set; }
        public Nullable<System.DateTime> cnt_date { get; set; }
        public Nullable<int> cnt_week { get; set; }
        public Nullable<int> cnt_year { get; set; }
        public Nullable<int> cnt_qty_system { get; set; }
        public Nullable<int> cnt_qty_counted { get; set; }
        public Nullable<System.DateTime> cnt_timestamp { get; set; }
        public Nullable<int> cnt_usrid { get; set; }
    }
}
