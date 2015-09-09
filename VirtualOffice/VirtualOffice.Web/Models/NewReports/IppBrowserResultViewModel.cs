using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class IppBrowserResultViewModel
    {
        public int id { get; set; }
        public System.DateTime timestamp { get; set; }
        public int merchant_fk { get; set; }
        public string vendorID { get; set; }
        public string accountNo { get; set; }
        public double amount { get; set; }
        public string fee_type { get; set; }
        public double merchantFeeShare { get; set; }
        public double fee { get; set; }
        public int status { get; set; }
        public bool reversed { get; set; }
        public Nullable<bool> acksent { get; set; }
        public bool ackflag { get; set; }
        public int type { get; set; }
    }
}