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
    
    public partial class Token
    {
        public int id { get; set; }
        public string value { get; set; }
        public int ApiUserId { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime TimeSpan { get; set; }
        public byte[] RowVersion { get; set; }
        public string ApiUserPassword { get; set; }
    
        public virtual ApiUser ApiUser { get; set; }
    }
}
