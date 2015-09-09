using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POSInvoiceDetail
    {
        public int det_id { get; set; }
        public int inv_id { get; set; }
        public Nullable<int> inv_carrier_fk { get; set; }
        public string inv_car_name { get; set; }
        public Nullable<int> inv_pin_fk { get; set; }
        public Nullable<double> inv_pin_controlno { get; set; }
        public Nullable<System.DateTime> inv_det_date { get; set; }
        public string product_sbt { get; set; }
        public string item_fk { get; set; }
        public string pro_description { get; set; }
        public Nullable<int> terminal_fk { get; set; }
        public Nullable<int> trn_quantity { get; set; }
        public Nullable<decimal> pro_denomination { get; set; }
        public Nullable<decimal> inv_Discount { get; set; }
        public Nullable<decimal> inv_subtotal { get; set; }
        public Nullable<int> inv_transaction_fk { get; set; }
        public Nullable<int> inv_Product_Isforeign { get; set; }
        public string inv_TransactionType { get; set; }
        public string inv_Cashier { get; set; }
        public Nullable<int> AccountingId { get; set; }
        public Nullable<decimal> ProductCost { get; set; }
        public Nullable<decimal> AgentCommission { get; set; }
        public Nullable<decimal> MDistCommission { get; set; }
        public Nullable<decimal> DistCommission { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> MDistId { get; set; }
        public Nullable<int> DistId { get; set; }
        public Nullable<System.DateTime> CommissionPaidDate { get; set; }
        public Nullable<bool> ProcessedInDirectBilling { get; set; }
    }
}
