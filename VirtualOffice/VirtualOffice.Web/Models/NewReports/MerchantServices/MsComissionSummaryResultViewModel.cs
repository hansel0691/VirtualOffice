using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports.MerchantServices
{
    public class MsComissionSummaryResultViewModel
    {
        public int code { get; set; }
        public string begindate { get; set; }
        public string enddate { get; set; }
        public Nullable<int> cnt_credits { get; set; }
        public Nullable<int> cnt_debits { get; set; }
        public Nullable<int> cnt_other { get; set; }
        public Nullable<int> cnt_total { get; set; }
        public double amt_sales { get; set; }
        public double amt_returns { get; set; }
        public double avg_ticket { get; set; }
        public double amex_commission { get; set; }
        public double vmc_commission { get; set; }
        public double oth_commission { get; set; }
        public double tot_commission { get; set; }
    }
}