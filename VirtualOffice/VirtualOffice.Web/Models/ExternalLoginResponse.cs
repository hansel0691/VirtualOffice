using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class ExternalLoginResponse
    {
        public string Token { get; set; }

        public string UserCategory { get; set; }
    }
}