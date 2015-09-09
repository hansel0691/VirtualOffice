using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidSalesDetailsResultViewModel
    {
        public int inv_id { get; set; }
        public string inv_date { get; set; }
        public double ld_sales { get; set; }
        public double pinless_sales { get; set; }
        public double wireless_sales { get; set; }
        public double international_sales { get; set; }
        public double other_sales { get; set; }
        public double debits { get; set; }
        public double credits { get; set; }
        public double total_sales { get; set; }
        public double mrch_commission { get; set; }
        public double net_sales { get; set; }
        public double agt_commission { get; set; }
        public double dst_commission { get; set; }
        public double iso_commission { get; set; }
    }
}