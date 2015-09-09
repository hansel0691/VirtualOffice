using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Invoices
    {
        public int invoiceID { get; set; }
        public Nullable<int> merchant_FK { get; set; }
        public Nullable<System.DateTime> ivDate { get; set; }
        public Nullable<short> ivStatus { get; set; }
        public Nullable<short> ivType { get; set; }
        public Nullable<int> orderID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> old_id { get; set; }
        public virtual POS_Inv_Orders1 POS_Inv_Orders1 { get; set; }
    }
}
