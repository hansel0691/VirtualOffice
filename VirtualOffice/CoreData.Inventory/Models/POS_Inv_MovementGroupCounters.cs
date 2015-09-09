using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_MovementGroupCounters
    {
        public int mov_Type { get; set; }
        public Nullable<int> mov_NextGroupID { get; set; }
    }
}
