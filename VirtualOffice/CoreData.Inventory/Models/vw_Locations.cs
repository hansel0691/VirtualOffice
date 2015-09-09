using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Locations
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string LocationType { get; set; }
    }
}
