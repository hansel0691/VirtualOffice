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
    
    public partial class UserReportFilter
    {
        public UserReportFilter()
        {
            this.UserReportFilterValues = new HashSet<UserReportFilterValue>();
        }
    
        public int Id { get; set; }
        public string ColunmName { get; set; }
        public byte[] RowVersion { get; set; }
        public System.DateTime TimeSpan { get; set; }
        public int UserReport_UserId { get; set; }
        public int UserReport_ReportId { get; set; }
        public bool Deleted { get; set; }
    
        public virtual UserReport UserReport { get; set; }
        public virtual ICollection<UserReportFilterValue> UserReportFilterValues { get; set; }
    }
}
