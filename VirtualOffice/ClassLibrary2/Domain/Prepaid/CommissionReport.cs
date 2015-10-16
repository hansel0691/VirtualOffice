using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class CommissionReport
    {
        public Nullable<int> Dist_ID { get; set; }
        public string Dist_Name { get; set; }
        public Nullable<int> ISO_ID { get; set; }
        public string ISO_Name { get; set; }
        public Nullable<int> Order { get; set; }
        public int Inv_ID { get; set; }
        public string Inv_Date { get; set; }
        public int Store { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> Denomination { get; set; }
        public Nullable<decimal> Merchant_Discount__ { get; set; }
        public Nullable<decimal> Dist_Comm__ { get; set; }
        public Nullable<decimal> ISO_Comm__ { get; set; }
    }
}
