using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class PrepaidSalesDetailsResult
    {
        public int inv_id { get; set; }
        public string inv_date { get; set; }
        public string ld_sales { get; set; }
        public string pinless_sales { get; set; }
        public string wireless_sales { get; set; }
        public string international_sales { get; set; }
        public string other_sales { get; set; }
        public string debits { get; set; }
        public string credits { get; set; }
        public string total_sales { get; set; }
        public string mrch_commission { get; set; }
        public string net_sales { get; set; }
        public string agt_commission { get; set; }
        public string dst_commission { get; set; }
        public string iso_commission { get; set; }
    }
}
