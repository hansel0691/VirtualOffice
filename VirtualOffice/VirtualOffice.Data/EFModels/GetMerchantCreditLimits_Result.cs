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
    
    public partial class GetMerchantCreditLimits_Result
    {
        public int merchant_pk { get; set; }
        public string mer_name { get; set; }
        public Nullable<decimal> dailylimit_max { get; set; }
        public Nullable<decimal> creditlimit_max { get; set; }
        public string dailyLevels { get; set; }
        public string creditLevels { get; set; }
    }
}
