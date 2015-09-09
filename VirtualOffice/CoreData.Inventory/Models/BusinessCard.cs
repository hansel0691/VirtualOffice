using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class BusinessCard
    {
        public int id { get; set; }
        public Nullable<int> agent_id { get; set; }
        public Nullable<int> merchant_pk { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> date_created { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> cartID { get; set; }
        public Nullable<int> orderID { get; set; }
    }
}
