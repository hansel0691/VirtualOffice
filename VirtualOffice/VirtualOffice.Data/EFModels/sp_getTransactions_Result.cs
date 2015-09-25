using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Data.EFModels
{
    public partial class sp_get_transactions_Result
    {
        public int? merchant_pk { get; set; }
        public string datestamp { get; set; }
        public string mer_name { get; set; }
        
        public string vmc_amount { get; set; }
        public string amex_amount { get; set; }
        public string dscv_amount { get; set; }
        public string ebt_amount { get; set; }
        public string oth_amount { get; set; }
        public string tran_amt { get; set; }
    }
}
