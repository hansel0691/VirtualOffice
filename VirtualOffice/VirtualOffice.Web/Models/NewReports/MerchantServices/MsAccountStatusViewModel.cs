﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports.MerchantServices
{
    public class MsAccountStatusViewModel
    {
        public int merchant_pk { get; set; }
        public string mer_name { get; set; }
        public string processingtype { get; set; }
        public string merchant_BusAddress { get; set; }
        public string merchant_AddressCityID { get; set; }
        public string merchant_AddressStateID { get; set; }
        public string merchant_AddressZIP { get; set; }
        public string merchant_maincontact { get; set; }
        public string merchant_maincontactphone { get; set; }
    }
}