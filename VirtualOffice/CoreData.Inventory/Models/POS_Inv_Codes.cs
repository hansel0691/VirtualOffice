using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Codes
    {
        public int codeID { get; set; }
        public string cdDescription { get; set; }
        public string cdFormat { get; set; }
        public string cdLastLexema { get; set; }
        public Nullable<decimal> cdCount { get; set; }
        public Nullable<decimal> cdCounterLen { get; set; }
    }
}
