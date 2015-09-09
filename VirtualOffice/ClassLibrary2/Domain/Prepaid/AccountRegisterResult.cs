using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class AccountRegisterResult
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
        public decimal? debit { get; set; }
        public decimal? credit { get; set; }
        public decimal? accBalance { get; set; }
    }
}
