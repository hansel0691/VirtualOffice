using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class MerchantCreditLimitResultViewModel
    {
        public int merchant_pk { get; set; }
        public string mer_name { get; set; }
        public Nullable<decimal> dailylimit_max { get; set; }
        public Nullable<decimal> creditlimit_max { get; set; }
        public string dailyLevels { get; set; }
        public string creditLevels { get; set; }
    }
}