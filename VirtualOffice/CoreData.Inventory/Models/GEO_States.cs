using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class GEO_States
    {
        public GEO_States()
        {
            this.GEO_Counties = new List<GEO_Counties>();
        }

        public int stateID { get; set; }
        public string stTwoLetters { get; set; }
        public string stName { get; set; }
        public virtual ICollection<GEO_Counties> GEO_Counties { get; set; }
    }
}
