using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class VirtualOfficeServiceResponse
    {
        public string ErrorMessage { get; set; }

        public object Data { get; set; }
    }
}