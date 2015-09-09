using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Reasons
    {
        public POS_Inv_Reasons()
        {
            this.POS_Inv_Movements = new List<POS_Inv_Movements>();
        }

        public int reasonID { get; set; }
        public string Reason { get; set; }
        public virtual ICollection<POS_Inv_Movements> POS_Inv_Movements { get; set; }
    }
}
