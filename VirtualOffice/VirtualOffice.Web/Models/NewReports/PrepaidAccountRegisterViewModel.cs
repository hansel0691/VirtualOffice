using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidAccountRegisterViewModel
    {
        public int reg_pk { get; set; }
        public int? distID { get; set; }
        public string distName { get; set; }
        public DateTime? transactionDate { get; set; }
        public string company { get; set; }
        public string transactionID { get; set; }
        public string transactionType { get; set; }
        public string description { get; set; }
        public int? accountID { get; set; }
        public string accountName { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public double accBalance { get; set; }
    }
}