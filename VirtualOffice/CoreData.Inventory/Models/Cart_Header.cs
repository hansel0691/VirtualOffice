using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class Cart_Header
    {
        public int ID { get; set; }
        public System.DateTime dateadded { get; set; }
        public int merchant_fk { get; set; }
        public decimal order_total { get; set; }
        public decimal order_tax { get; set; }
        public decimal order_discount { get; set; }
        public decimal order_net { get; set; }
        public string orShipTo { get; set; }
        public string orShipAddress1 { get; set; }
        public string orShipAddress2 { get; set; }
        public string orShipCity { get; set; }
        public string orShipState { get; set; }
        public string orShipZipCode { get; set; }
        public string orShipCountry { get; set; }
        public string orShipPhone { get; set; }
        public string orRefNotes { get; set; }
        public double orTotalWeight { get; set; }
        public int orWeight_measureID { get; set; }
        public int deploymethID { get; set; }
        public bool FedExHomeDelivery { get; set; }
        public bool FedExSaturdayDelivery { get; set; }
        public short orShipType { get; set; }
        public int pmt_method { get; set; }
        public decimal orShipCost { get; set; }
        public string orComment { get; set; }
        public int agentID { get; set; }
        public string orShipEmail { get; set; }
    }
}
