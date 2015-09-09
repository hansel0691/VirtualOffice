using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Packages
    {
        public POS_Inv_Packages()
        {
            this.POS_Inv_PackageByOrder = new List<POS_Inv_PackageByOrder>();
        }

        public int packageID { get; set; }
        public Nullable<int> thingID { get; set; }
        public Nullable<decimal> pkQuantity { get; set; }
        public string pkDescription { get; set; }
        public Nullable<int> maxQtyShipFree { get; set; }
        public Nullable<decimal> pkPrice { get; set; }
        public Nullable<byte> pkType { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> sort_asc { get; set; }
        public Nullable<int> prd_showrma { get; set; }
        public Nullable<int> rma_replaceable { get; set; }
        public Nullable<decimal> dist_discount { get; set; }
        public string product_sbt { get; set; }
        public string filename { get; set; }
        public string lastupload_by { get; set; }
        public Nullable<System.DateTime> lastupload_date { get; set; }
        public virtual ICollection<POS_Inv_PackageByOrder> POS_Inv_PackageByOrder { get; set; }
    }
}
