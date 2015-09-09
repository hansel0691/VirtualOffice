using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class GEO_Zips
    {
        public int cityID { get; set; }
        public string ZipCode { get; set; }
        public virtual GEO_Cities GEO_Cities { get; set; }
    }
}
