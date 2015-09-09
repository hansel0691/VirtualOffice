using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_PaymentTypes
    {
        public int paymenttypeID { get; set; }
        public string ptDescription { get; set; }
        public Nullable<short> ptType { get; set; }
    }
}
