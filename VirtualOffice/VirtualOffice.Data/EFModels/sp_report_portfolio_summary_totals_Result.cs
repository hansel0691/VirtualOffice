//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualOffice.Data.EFModels
{
    using System;
    
    public partial class sp_report_portfolio_summary_totals_Result
    {
        public int PrepaidAccounts_Actives { get; set; }
        public int PrepaidAccounts_inactives { get; set; }
        public int AccountsInAlert_incompliance { get; set; }
        public int AccountsInAlert_suspended { get; set; }
        public int AccountsInAlert_closedwithbalance { get; set; }
        public decimal GrSalesTOT { get; set; }
        public decimal BillPayment { get; set; }
        public decimal Running_Commission { get; set; }
        public decimal TodayTransactions { get; set; }
        public int MSAccounts_Actives { get; set; }
        public int MSAccounts_inactives { get; set; }
        public int MSCommissionsVISAMCAME { get; set; }
        public int MSCommissionsOthers { get; set; }
        public int MSCommissionsTotal { get; set; }
        public int MSApplicationsApproved { get; set; }
        public int MSApplicationsPending { get; set; }
        public int MSApplicationsCanceled { get; set; }
    }
}
