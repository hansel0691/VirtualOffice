using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Things
    {
        public POS_Inv_Things()
        {
            this.POS_Inv_Purchases = new List<POS_Inv_Purchases>();
            this.POS_Inv_ThingsByOrder = new List<POS_Inv_ThingsByOrder>();
            this.POS_Inv_ThingsByProvider = new List<POS_Inv_ThingsByProvider>();
        }

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
        public virtual POS_Inv_Measures POS_Inv_Measures { get; set; }
        public virtual POS_Inv_Measures POS_Inv_Measures1 { get; set; }
        public virtual POS_Inv_Measures POS_Inv_Measures2 { get; set; }
        public virtual ICollection<POS_Inv_Purchases> POS_Inv_Purchases { get; set; }
        public virtual ICollection<POS_Inv_ThingsByOrder> POS_Inv_ThingsByOrder { get; set; }
        public virtual ICollection<POS_Inv_ThingsByProvider> POS_Inv_ThingsByProvider { get; set; }
    }
}
