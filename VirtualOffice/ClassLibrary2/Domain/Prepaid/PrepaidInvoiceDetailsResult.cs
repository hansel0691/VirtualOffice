using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class PrepaidInvoiceDetailsResult
    {
        public int det_id { get; set; }
        public string inv_det_date { get; set; }
        public string product_maincode { get; set; }
        public string pro_rootname { get; set; }
        public string pro_denomination { get; set; }
        public string inv_discount { get; set; }
        public string inv_subtotal { get; set; }
        public string agentcommission { get; set; }
        public string distcommission { get; set; }
        public string mdistcommission { get; set; }
        public string phone_number { get; set; }
    }
}
