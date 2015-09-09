using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Providers
    {
        public POS_Inv_Providers()
        {
            this.POS_Inv_Purchases = new List<POS_Inv_Purchases>();
            this.POS_Inv_ThingsByProvider = new List<POS_Inv_ThingsByProvider>();
        }

        public int providerID { get; set; }
        public string pdName { get; set; }
        public virtual ICollection<POS_Inv_Purchases> POS_Inv_Purchases { get; set; }
        public virtual ICollection<POS_Inv_ThingsByProvider> POS_Inv_ThingsByProvider { get; set; }
    }
}
