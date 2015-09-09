using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_AuxCreateThing
    {
        public string POSCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> Amount_MeasureID { get; set; }
        public Nullable<int> Weight_MeasureID { get; set; }
        public Nullable<double> Weight { get; set; }
        public string Item_FK { get; set; }
        public string SBTCode { get; set; }
        public string UserName { get; set; }
    }
}
