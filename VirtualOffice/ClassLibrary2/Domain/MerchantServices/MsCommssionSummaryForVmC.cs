using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.MerchantServices
{
    public class MsCommssionSummaryForVmC
    {
        public string merchantnumber { get; set; }
        public string name { get; set; }
        public int cnt_credits { get; set; }
        public int cnt_debits { get; set; }
        public int cnt_other { get; set; }
        public int cnt_total { get; set; }
        public string amt_sales { get; set; }
        public string avg_ticket { get; set; }
        public string income { get; set; }
        public string expenses { get; set; }
        public string netincome { get; set; }
        public string commisison { get; set; }
        public string adjustments { get; set; }
    }
}
