﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class TransactionSummaryResult
    {
        public DateTime? Date_Time { get; set; }
        public int Store { get; set; }
        public string Store_Name { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? Qty { get; set; }
        public decimal? Gross_Sale { get; set; }

        public string Cahier_id { get; set; }

    }
}
