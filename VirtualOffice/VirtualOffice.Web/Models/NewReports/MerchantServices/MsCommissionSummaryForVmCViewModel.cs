using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports.MerchantServices
{
    public class MsCommissionSummaryForVmCViewModel
    {
        public string merchantnumber { get; set; }
        public string name { get; set; }
        public int cnt_credits { get; set; }
        public int cnt_debits { get; set; }
        public int cnt_other { get; set; }
        public int cnt_total { get; set; }
        public double amt_sales { get; set; }
        public double avg_ticket { get; set; }
        public double income { get; set; }
        public double expenses { get; set; }
        public double netincome { get; set; }
        public double commisison { get; set; }
        public double adjustments { get; set; }
    }
}