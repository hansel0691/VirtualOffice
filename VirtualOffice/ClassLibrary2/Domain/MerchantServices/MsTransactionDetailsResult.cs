using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.MerchantServices
{
    public class MsTransactionDetailsResult
    {
        public DateTime date_time { get; set; }
        public string merchant { get; set; }
        public string card_type { get; set; }
        public string card_number { get; set; }
        public string trans_type { get; set; }
        public string category { get; set; }
        public double amount { get; set; }
    }
}
