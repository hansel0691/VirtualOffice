using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidTodayTransactionsViewModel
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public string TrxType_hyp_fk { get; set; }
        public string Product_Hyp_fk { get; set; }
        public string pro_description { get; set; }
        public string mer_MID { get; set; }
        public string mer_name { get; set; }
        public double amount { get; set; }
        public string language { get; set; }
        public Nullable<int> carrier_fk { get; set; }
        public Nullable<double> pin_controlno { get; set; }
        public string product_sbt { get; set; }
        public Nullable<int> systemtracenumber { get; set; }
        public string TransPaymentMethod { get; set; }
        public string SaleStatus { get; set; }
        public string OriginalSaleDate { get; set; }
        public string merchant_BusAddress { get; set; }
        public string merchant_AddressCityID { get; set; }
        public string merchant_AddressStateID { get; set; }
        public string merchant_AddressZIP { get; set; }
        public string merchant_busphone { get; set; }
        public string Status_Message { get; set; }
        public int ReversedTrans { get; set; }
        public Nullable<int> SettledSale { get; set; }
        public Nullable<bool> vending { get; set; }
        public int VendingType { get; set; }
    }
}