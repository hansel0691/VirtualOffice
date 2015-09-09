using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Merchants
    {
        public int ID { get; set; }
        public string MerchantName { get; set; }
        public string MerchantDBA { get; set; }
        public string City { get; set; }
        public string StateLetters { get; set; }
        public string StateName { get; set; }
    }
}
