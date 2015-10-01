﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.MerchantServices
{
    public class MsPortfolioResult
    {
        public int merchant_pk { get; set; }
        public string mer_name { get; set; }
        public string mer_appdate { get; set; }
        public string mer_midBank { get; set; }
        public string merchant_busaddress { get; set; }
        public string merchant_addressCityID { get; set; }
        public string merchant_addressStateID { get; set; }
        public string merchant_addressZip { get; set; }
        public string merchant_guarantorname { get; set; }
        public string merchant_busphone { get; set; }
        public string merchant_email { get; set; }
        public int Status { get; set; }
    }
}
