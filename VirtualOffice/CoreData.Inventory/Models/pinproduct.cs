using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class pinproduct
    {
        public string product_sbt { get; set; }
        public string item_fk { get; set; }
        public Nullable<int> carrier_fk { get; set; }
        public Nullable<int> PosProductline_fk { get; set; }
        public string pro_productlineID { get; set; }
        public string pro_productcode { get; set; }
        public string pro_productname { get; set; }
        public string pro_description { get; set; }
        public Nullable<decimal> pro_denomination { get; set; }
        public string pro_customerphone { get; set; }
        public string pro_expiretype { get; set; }
        public Nullable<int> pro_expiredays { get; set; }
        public Nullable<System.DateTime> pro_timestamp { get; set; }
        public string pro_useradder { get; set; }
        public Nullable<System.DateTime> pro_dateadded { get; set; }
        public string pro_usereditor { get; set; }
        public Nullable<System.DateTime> pro_dateeditor { get; set; }
        public string instantpin { get; set; }
        public string mailorder { get; set; }
        public Nullable<bool> pos { get; set; }
        public Nullable<int> pos_reorder { get; set; }
        public Nullable<bool> eCommerce { get; set; }
        public Nullable<int> eComm_reorder { get; set; }
        public Nullable<decimal> SalesAgentCommission { get; set; }
        public Nullable<int> Isforeign { get; set; }
        public Nullable<int> pmg_fk { get; set; }
        public Nullable<int> POSCategoryID { get; set; }
        public Nullable<int> PosBillingCode { get; set; }
        public string Product_MainCode { get; set; }
    }
}
