using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class VirtualOfficeReportModel
    {
        public Dictionary<string, ColumnConfig> ColumnsConfig { get; set; }
        public DateRange DateRange { get; set; }
        public IEnumerable<Dictionary<string, object>> Data { get; set; }
        public string PrintLink { get; set; }
        public string StoreProcedureName { get; set; }
    }
}