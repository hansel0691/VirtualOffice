using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidAccountsInCollectionViewModel
    {
        public Nullable<int> agentID { get; set; }
        public string legalName { get; set; }
        public string Company { get; set; }
        public int merchant_pk { get; set; }
        public string mer_name { get; set; }
        public System.DateTime suspended_date { get; set; }
        public string accBalance { get; set; }
        public string balanceToBeTransferred { get; set; }
        public Nullable<decimal> dscCommission { get; set; }
        public Nullable<decimal> badDebtBalance { get; set; }
        public Nullable<System.DateTime> transfer_date { get; set; }
        public int collection_incidents { get; set; }
        public string collection_lastContact { get; set; }
        public string merchant_DBA { get; set; }
        public int MerType { get; set; }
        public string reportSource { get; set; }
    }
}