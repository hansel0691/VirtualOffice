//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualOfficeToolManager.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserReport
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public string Output { get; set; }
        public byte[] RowVersion { get; set; }
        public System.DateTime TimeSpan { get; set; }
        public string Name { get; set; }
        public string OutputConfiguration { get; set; }
    
        public virtual Report Report { get; set; }
        public virtual User User { get; set; }
    }
}
