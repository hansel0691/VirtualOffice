using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Measures
    {
        public POS_Inv_Measures()
        {
            this.POS_Inv_PackageByOrder = new List<POS_Inv_PackageByOrder>();
            this.POS_Inv_Things = new List<POS_Inv_Things>();
            this.POS_Inv_Things1 = new List<POS_Inv_Things>();
            this.POS_Inv_Things2 = new List<POS_Inv_Things>();
        }

        public int measureID { get; set; }
        public string msName { get; set; }
        public string msSymbol { get; set; }
        public virtual ICollection<POS_Inv_PackageByOrder> POS_Inv_PackageByOrder { get; set; }
        public virtual ICollection<POS_Inv_Things> POS_Inv_Things { get; set; }
        public virtual ICollection<POS_Inv_Things> POS_Inv_Things1 { get; set; }
        public virtual ICollection<POS_Inv_Things> POS_Inv_Things2 { get; set; }
    }
}
