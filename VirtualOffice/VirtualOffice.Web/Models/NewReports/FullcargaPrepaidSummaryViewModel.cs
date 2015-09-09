using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class FullcargaPrepaidSummaryViewModel
    {
        public int Store { get; set; }
        public string Store_Name { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Qty { get; set; }
        public decimal? Gross_Sale { get; set; }
        public decimal? Net_Sale { get; set; }
        public decimal? Merchant_Comm_V { get; set; }
        public decimal? Dist_Comm_V { get; set; }
        public decimal? ISO_Comm_V { get; set; }
    }
}