using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports.MerchantServices
{
    public class MsCommissionSummaryForOthersViewModel
    {
        public string merchantnumber { get; set; }
        public string merchantname { get; set; }
        public int? cnt_credits { get; set; }
        public int? cnt_debits { get; set; }
        public int? cnt_other { get; set; }
        public int? cnt_total { get; set; }
        public double amt_sales { get; set; }
        public double avg_ticket { get; set; }
        public double income { get; set; }
        public double expenses { get; set; }
        public double netincome { get; set; }
        public double commission { get; set; }
        public double adjustments { get; set; }
    }
}