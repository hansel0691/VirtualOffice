using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidInvoiceDetailsResultViewModel
    {
        public int det_id { get; set; }
        public string inv_det_date { get; set; }
        public string product_maincode { get; set; }
        public string pro_rootname { get; set; }
        public double pro_denomination { get; set; }
        public double inv_discount { get; set; }
        public double inv_subtotal { get; set; }
        public double agentcommission { get; set; }
        public double distcommission { get; set; }
        public double mdistcommission { get; set; }
        public string phone_number { get; set; }
    }
}