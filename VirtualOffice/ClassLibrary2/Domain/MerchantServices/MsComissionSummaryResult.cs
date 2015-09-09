using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.MerchantServices
{
    public class MsComissionSummaryResult
    {
        public int code { get; set; }
        public string begindate { get; set; }
        public string enddate { get; set; }
        public Nullable<int> cnt_credits { get; set; }
        public Nullable<int> cnt_debits { get; set; }
        public Nullable<int> cnt_other { get; set; }
        public Nullable<int> cnt_total { get; set; }
        public string amt_sales { get; set; }
        public string amt_returns { get; set; }
        public string avg_ticket { get; set; }
        public string amex_commission { get; set; }
        public string vmc_commission { get; set; }
        public string oth_commission { get; set; }
        public string tot_commission { get; set; }
    }
}
