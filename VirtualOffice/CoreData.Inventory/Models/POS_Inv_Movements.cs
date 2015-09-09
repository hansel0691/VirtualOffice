using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Movements
    {
        public int movementID { get; set; }
        public Nullable<int> itemID { get; set; }
        public Nullable<System.DateTime> mvDate { get; set; }
        public Nullable<short> mvType { get; set; }
        public Nullable<int> reasonID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> mvGroup { get; set; }
        public virtual POS_Inv_Entries POS_Inv_Entries { get; set; }
        public virtual POS_Inv_Items POS_Inv_Items { get; set; }
        public virtual POS_Inv_Reasons POS_Inv_Reasons { get; set; }
        public virtual POS_Inv_Replacements POS_Inv_Replacements { get; set; }
        public virtual POS_Inv_Returns POS_Inv_Returns { get; set; }
        public virtual POS_Inv_Rotations POS_Inv_Rotations { get; set; }
        public virtual POS_Inv_Sales POS_Inv_Sales { get; set; }
        public virtual POS_Inv_Sustitutions POS_Inv_Sustitutions { get; set; }
        public virtual POS_Inv_Transferences POS_Inv_Transferences { get; set; }
    }
}
