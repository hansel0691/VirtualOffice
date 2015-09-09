using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace VirtualOffice.Web.Models
{
    public class ReportInfoModel
    {
        public int ReportId { get; set; }
        public IEnumerable<Argument> Args { get; set; }
    }

    public class UserReportInfoModel : ReportInfoModel
    {
        public int UserId { get; set; }
    }

    public class UserReportFilterConfiguration
    {
        public UserReportInfoModel UserReportInfo { get; set; }

        public IEnumerable<UserReportFilterModel> Filters { get; set; }
    }

    public class UserReportFilterModel
    {
        public string ColumnName { get; set; }

        public string Value { get; set; }
    }

    public class UserReportOutputModel
    {
        public int UserId { get; set; }

        public int ReportId { get; set; }

        public string Output { get; set; }

        public string OutputConfiguration { get; set; }
    }

    public class MyKeyValuePair
    {
        public string Key { get; set; }

        public object Value { get; set; }

    }
}