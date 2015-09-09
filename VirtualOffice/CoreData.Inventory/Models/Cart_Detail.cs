using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class Cart_Detail
    {
        public int id { get; set; }
        public int cart_id { get; set; }
        public string thType { get; set; }
        public int thingID { get; set; }
        public string description { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
        public decimal extended { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public int order_id { get; set; }
        public string unit { get; set; }
        public double weight { get; set; }
        public int weight_measureID { get; set; }
    }
}
