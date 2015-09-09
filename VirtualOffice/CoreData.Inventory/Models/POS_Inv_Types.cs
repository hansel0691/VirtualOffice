using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Types
    {
        public int typeID { get; set; }
        public string typCategory { get; set; }
        public string typDescription { get; set; }
        public Nullable<int> typValue { get; set; }
    }
}
