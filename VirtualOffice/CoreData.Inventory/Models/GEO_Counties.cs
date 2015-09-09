using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class GEO_Counties
    {
        public GEO_Counties()
        {
            this.GEO_Cities = new List<GEO_Cities>();
        }

        public int countyID { get; set; }
        public Nullable<int> stateID { get; set; }
        public string ctName { get; set; }
        public virtual ICollection<GEO_Cities> GEO_Cities { get; set; }
        public virtual GEO_States GEO_States { get; set; }
    }
}
