using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_LocationTypes
    {
        public int locationtypeID { get; set; }
        public string ltDescription { get; set; }
        public Nullable<short> ltLocGroup { get; set; }
    }
}
