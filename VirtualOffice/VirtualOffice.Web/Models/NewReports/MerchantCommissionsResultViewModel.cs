using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class MerchantCommissionsResultViewModel
    {
        public int merchant_fk { get; set; }
        public string pro_description { get; set; }
        public string Product_MainCode { get; set; }
        public int? pro_Type { get; set; }
        public string pro_TypeDesc { get; set; }
        public string ProfCommMerchant { get; set; }
        public string ProfCommAgent { get; set; }
        public string ProfCommDist { get; set; }
        public string ProfCommISO { get; set; }
        public string ProfCommTotal { get; set; }
    }
}