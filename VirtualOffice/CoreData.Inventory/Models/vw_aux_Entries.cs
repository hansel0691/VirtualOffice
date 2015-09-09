using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_aux_Entries
    {
        public int Move { get; set; }
        public Nullable<int> Item { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<System.DateTime> MoveDate { get; set; }
        public Nullable<short> MoveType { get; set; }
        public string Reason { get; set; }
        public string UserNick { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}
