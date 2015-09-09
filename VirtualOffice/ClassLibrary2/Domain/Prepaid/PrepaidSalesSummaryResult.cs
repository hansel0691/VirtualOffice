using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class PrepaidSalesSummaryResult
    {
        public int mid { get; set; }
        public string mer_name { get; set; }
        public string grSalesLD { get; set; }
        public string grSalesCEL { get; set; }
        public string grSalesOTH { get; set; }
        public string GrSalesTOT { get; set; }
        public string mchCommission { get; set; }
        public string feesANDcredits { get; set; }
        public string netSales { get; set; }
        public string agtCommission { get; set; }
        public string dstCommission { get; set; }
        public string isoCommission { get; set; }
        public string accBalance { get; set; }
    }
}
