
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
    
public partial class sp_report_balance_details_Result
{

    public int inv_id { get; set; }

    public string inv_date { get; set; }

    public string gr_sales { get; set; }

    public Nullable<decimal> nt_sales { get; set; }

    public decimal invoice_payments { get; set; }

    public Nullable<decimal> invoice_balance { get; set; }

    public string invoice_last_payment { get; set; }

}

}
