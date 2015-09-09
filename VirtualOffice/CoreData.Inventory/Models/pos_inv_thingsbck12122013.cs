using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class pos_inv_thingsbck12122013
    {
        public int thingID { get; set; }
        public string thCode { get; set; }
        public string thDescription { get; set; }
        public Nullable<int> thStockAmount { get; set; }
        public Nullable<int> thReservedAmount { get; set; }
        public Nullable<int> thMinimumAmount { get; set; }
        public Nullable<int> Amount_measureID { get; set; }
        public Nullable<decimal> thCost { get; set; }
        public Nullable<decimal> thPrice { get; set; }
        public Nullable<byte> thStatus { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> Weight_measureID { get; set; }
        public Nullable<double> Length { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<int> Dimension_measureID { get; set; }
        public string item_fk { get; set; }
        public Nullable<int> thType { get; set; }
        public Nullable<decimal> thDiscount { get; set; }
        public Nullable<decimal> thAgentComm { get; set; }
        public Nullable<decimal> thDistComm { get; set; }
        public Nullable<decimal> thMDistComm { get; set; }
    }
}
