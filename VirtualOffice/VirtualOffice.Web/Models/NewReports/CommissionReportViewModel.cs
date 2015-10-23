using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class CommissionReportViewModel
    {
        public Nullable<int> DistID { get; set; }
        public string DistName { get; set; }
        public Nullable<int> ISOID { get; set; }
        public string ISOName { get; set; }
        public Nullable<int> Order { get; set; }
        public int InvID { get; set; }
        public string InvDate { get; set; }
        public int Store { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> MerchantDiscount { get; set; }
        public Nullable<decimal> DistComm { get; set; }
        public Nullable<decimal> ISOComm { get; set; }
    }
}