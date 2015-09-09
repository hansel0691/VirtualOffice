using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class SalesSummary
    {
        public string Month { get; set; }
        public double PrepaidSalesSummary { get; set; }
        public string PP_Link { get; set; }
        public double MerchantServicesSalesSummary { get; set; }
        public string MS_Link { get; set; }
    }

    public class ReportSummary
    {
        public string Link { get; set; }
        public double Total { get; set; }
    }
}