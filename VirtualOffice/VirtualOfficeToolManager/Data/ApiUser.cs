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
    
    public partial class ApiUser
    {
        public ApiUser()
        {
            this.Tokens = new HashSet<Token>();
        }
    
        public int id { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] RowVersion { get; set; }
        public System.DateTime TimeSpan { get; set; }
    
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
