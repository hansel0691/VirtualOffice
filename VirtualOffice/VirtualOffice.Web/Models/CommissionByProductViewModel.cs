using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class CommissionByProductViewModel
    {
        public string ProductCode { get; set; }
        public string UserId { get; set; }
        public string UserDescription { get; set; }
        public string Product { get; set; }
        public double MyCommission { get; set; }
        public double Actual { get; set; }
        public double OldCommission { get; set; }
    }
}