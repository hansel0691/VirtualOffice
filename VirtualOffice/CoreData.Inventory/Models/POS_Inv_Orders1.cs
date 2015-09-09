using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Orders1
    {
        public POS_Inv_Orders1()
        {
            this.POS_Inv_Invoices = new List<POS_Inv_Invoices>();
        }

        public int orderID { get; set; }
        public string orCode { get; set; }
        public Nullable<System.DateTime> orQueuedDate { get; set; }
        public Nullable<System.DateTime> orPrepareDate { get; set; }
        public Nullable<System.DateTime> orProcessedDate { get; set; }
        public Nullable<short> orStatus { get; set; }
        public Nullable<short> orPriority { get; set; }
        public Nullable<long> merchant_FK { get; set; }
        public Nullable<int> deploymethID { get; set; }
        public Nullable<bool> FedExHomeDelivery { get; set; }
        public Nullable<bool> FedExSaturdayDelivery { get; set; }
        public Nullable<short> orType { get; set; }
        public Nullable<int> Incident { get; set; }
        public Nullable<int> orPreparedBy { get; set; }
        public Nullable<int> orProcessedBy { get; set; }
        public string orShipTo { get; set; }
        public string orShipAddress1 { get; set; }
        public string orShipAddress2 { get; set; }
        public string orShipCity { get; set; }
        public string orShipState { get; set; }
        public string orShipZipCode { get; set; }
        public string orShipPhone { get; set; }
        public string orShipTrackingNumber { get; set; }
        public string orShipCODTrackingNumber { get; set; }
        public string orRefNotes { get; set; }
        public string orComment { get; set; }
        public Nullable<int> inv_id_FK { get; set; }
        public Nullable<decimal> order_tax { get; set; }
        public Nullable<decimal> order_discount { get; set; }
        public Nullable<decimal> order_net { get; set; }
        public Nullable<int> pmt_method { get; set; }
        public string cc_type { get; set; }
        public Nullable<int> exp_month { get; set; }
        public Nullable<int> exp_year { get; set; }
        public string approval_code { get; set; }
        public string fraudcode { get; set; }
        public string fraudscore { get; set; }
        public string fraudreason1 { get; set; }
        public string fraudreason2 { get; set; }
        public string fraudreason3 { get; set; }
        public string ccaddress1 { get; set; }
        public string ccaddress2 { get; set; }
        public string ccCity { get; set; }
        public string ccState { get; set; }
        public string ccCountry { get; set; }
        public string ccphone { get; set; }
        public string ccZip { get; set; }
        public string ccFirstName { get; set; }
        public string ccLastName { get; set; }
        public string incident_username { get; set; }
        public string acct_rep { get; set; }
        public Nullable<System.DateTime> Queue_Date { get; set; }
        public virtual POS_Inv_DeployMethods POS_Inv_DeployMethods { get; set; }
        public virtual ICollection<POS_Inv_Invoices> POS_Inv_Invoices { get; set; }
    }
}
