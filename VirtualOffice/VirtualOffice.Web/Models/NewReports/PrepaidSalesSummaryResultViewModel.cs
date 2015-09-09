using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidSalesSummaryResultViewModel
    {
        public int mid { get; set; }
        public string mer_name { get; set; }
        public double grSalesLD { get; set; }
        public double grSalesCEL { get; set; }
        public double grSalesOTH { get; set; }
        public double GrSalesTOT { get; set; }
        public double mchCommission { get; set; }
        public double feesANDcredits { get; set; }
        public double netSales { get; set; }
        public double agtCommission { get; set; }
        public double dstCommission { get; set; }
        public double isoCommission { get; set; }
        public double accBalance { get; set; }
    }
}