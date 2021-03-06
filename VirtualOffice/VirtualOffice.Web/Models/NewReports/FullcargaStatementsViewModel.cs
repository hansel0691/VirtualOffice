﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class FullcargaStatementsViewModel
    {
        public int Invoice { get; set; }
        public Nullable<int> Billed { get; set; }
        public string Billed_Name { get; set; }
        public Nullable<System.DateTime> Inv_Date { get; set; }
        public Nullable<decimal> Invoice_Amount { get; set; }
        public string Status { get; set; }
    }
}