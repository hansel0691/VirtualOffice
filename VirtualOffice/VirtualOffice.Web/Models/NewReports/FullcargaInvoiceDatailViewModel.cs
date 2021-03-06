﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class FullcargaInvoiceDetailViewModel
    {
        public int Id { get; set; }
        public int Store { get; set; }
        public string Store_Name { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public decimal? Denomination { get; set; }
        public decimal? Net_Sale { get; set; }
    }
}