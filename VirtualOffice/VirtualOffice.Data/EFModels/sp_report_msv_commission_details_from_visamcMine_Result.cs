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
    
    public partial class sp_report_msv_commission_details_from_visamcMine_Result
    {
        public string merchantnumber { get; set; }
        public string name { get; set; }
        public int cnt_credits { get; set; }
        public int cnt_debits { get; set; }
        public int cnt_other { get; set; }
        public int cnt_total { get; set; }
        public string amt_sales { get; set; }
        public string avg_ticket { get; set; }
        public Nullable<decimal> income { get; set; }
        public Nullable<decimal> expenses { get; set; }
        public Nullable<decimal> netincome { get; set; }
        public Nullable<decimal> commission { get; set; }
        public string adjustments { get; set; }
    }
}
