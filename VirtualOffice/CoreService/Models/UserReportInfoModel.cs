using System.Collections.Generic;

namespace CoreService.Models
{
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

    public class UserReportOutputModel : UserReportInfoModel
    {
        public string Output { get; set; }
        public string OutputConfiguration { get; set; }
    }
}