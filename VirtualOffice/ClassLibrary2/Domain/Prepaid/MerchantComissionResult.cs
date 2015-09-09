﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class MerchantComissionResult
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
