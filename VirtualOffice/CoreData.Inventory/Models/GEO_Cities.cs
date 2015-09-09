using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class GEO_Cities
    {
        public GEO_Cities()
        {
            this.GEO_Zips = new List<GEO_Zips>();
        }

        public int cityID { get; set; }
        public Nullable<int> countyID { get; set; }
        public string ctyName { get; set; }
        public virtual GEO_Counties GEO_Counties { get; set; }
        public virtual ICollection<GEO_Zips> GEO_Zips { get; set; }
    }
}
