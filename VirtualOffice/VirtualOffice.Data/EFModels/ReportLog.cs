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
    using System.Collections.Generic;
    
    public partial class ReportLog
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public Nullable<System.DateTime> TimeSpan { get; set; }
        public Nullable<int> ReportCount { get; set; }
        public string ErrorMessage { get; set; }
        public string AgentId { get; set; }
    }
}
