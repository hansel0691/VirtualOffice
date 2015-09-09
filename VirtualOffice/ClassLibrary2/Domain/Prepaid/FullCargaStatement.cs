using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class FullCargaStatement
    {
        public int Invoice { get; set; }
        public Nullable<int> Billed { get; set; }
        public string Billed_Name { get; set; }
        public Nullable<System.DateTime> Inv_Date { get; set; }
        public Nullable<decimal> Invoice_Amount { get; set; }
        public string Status { get; set; }
    }
}
