using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports.MerchantServices
{
    public class MsTransactionSummaryViewModel
    {
        public int merchant_pk { get; set; }
        public DateTime datestamp { get; set; }
        public string mer_name { get; set; }
        public double vmc_amount { get; set; }
        public double amex_amount { get; set; }
        public double dscv_amount { get; set; }
        public double ebt_amount { get; set; }
        public double oth_amount { get; set; }
        public double tran_amt { get; set; }
    }
}