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
    
    public partial class SP_Send_AgentToBillMerchants_Result
    {
        public int DistISOID { get; set; }
        public string DistISOName { get; set; }
        public Nullable<int> Order { get; set; }
        public string Phone { get; set; }
        public int InvID { get; set; }
        public string InvDate { get; set; }
        public int Store { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> Denomination { get; set; }
        public Nullable<decimal> NetSale { get; set; }
        public Nullable<decimal> ISOCommD { get; set; }
        public Nullable<decimal> ISOCommP { get; set; }
        public Nullable<decimal> DistCommM { get; set; }
        public Nullable<decimal> DistCommP { get; set; }
        public Nullable<decimal> MerchCommM { get; set; }
        public Nullable<decimal> MerchCommP { get; set; }
        public Nullable<decimal> Margin { get; set; }
    }
}
