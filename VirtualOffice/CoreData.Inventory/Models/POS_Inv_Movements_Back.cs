using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Movements_Back
    {
        public int movementID { get; set; }
        public Nullable<int> itemID { get; set; }
        public Nullable<System.DateTime> mvDate { get; set; }
        public Nullable<short> mvType { get; set; }
        public Nullable<int> reasonID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> mvGroup { get; set; }
    }
}
