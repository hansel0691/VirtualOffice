using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class ApiToken
    {
        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}