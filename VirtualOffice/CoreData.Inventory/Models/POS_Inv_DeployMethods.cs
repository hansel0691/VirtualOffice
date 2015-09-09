using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_DeployMethods
    {
        public POS_Inv_DeployMethods()
        {
            this.POS_Inv_Orders1 = new List<POS_Inv_Orders1>();
        }

        public int deploymethID { get; set; }
        public string dmDescription { get; set; }
        public string dmFedexCode { get; set; }
        public string dmTransitTime { get; set; }
        public Nullable<int> POS_deploymethod_fk { get; set; }
        public Nullable<short> dmTransitTimeDays { get; set; }
        public Nullable<bool> dmTransitTimeBusinessDays { get; set; }
        public virtual ICollection<POS_Inv_Orders1> POS_Inv_Orders1 { get; set; }
    }
}
