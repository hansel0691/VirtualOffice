using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Applications
    {
        public POS_Inv_Applications()
        {
            this.POS_Inv_Equipment = new List<POS_Inv_Equipment>();
        }

        public int applicationID { get; set; }
        public string apName { get; set; }
        public string AppCode_F { get; set; }
        public virtual ICollection<POS_Inv_Equipment> POS_Inv_Equipment { get; set; }
    }
}
