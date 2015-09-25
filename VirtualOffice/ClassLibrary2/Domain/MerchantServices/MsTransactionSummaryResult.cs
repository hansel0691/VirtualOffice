using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.MerchantServices
{
    public class MsTransactionSummaryResult
    {
        public int? merchant_pk { get; set; }
        public DateTime? datestamp { get; set; }
        public string mer_name { get; set; }

        public string vmc_amount { get; set; }
        public string amex_amount { get; set; }
        public string dscv_amount { get; set; }
        public string ebt_amount { get; set; }
        public string oth_amount { get; set; }
        public string tran_amt { get; set; }
    }
}
