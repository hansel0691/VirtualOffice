using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_OrderCCVerify
    {
        public int orderID { get; set; }
        public string cc_cvv2 { get; set; }
    }
}
