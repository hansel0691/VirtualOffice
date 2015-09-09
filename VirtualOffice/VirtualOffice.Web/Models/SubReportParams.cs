using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class SubReportParams
    {

        public int ReportId { get; set; }
        public int SubReportId { get; set; }
        public string IndexParamName { get; set; }
        public string IndexParamValue { get; set; }
        public string ColumnName { get; set; }
        public string ParameterName { get; set; }
        public string ColumnValue { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }

    }
}