using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class UserReportViewModel : ReportConfigViewModel
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }

        public string DefaultOuput { get; set; }

        public string OutputConfiguration { get; set; }

        public List<MyKeyValuePair> UserFiltersConfig { get; set; }

        public IDictionary<string, IEnumerable<string>> FiltersData { get; set; }

        public int RowCount { get; set; }

        public bool ShouldBeShownAtDesktop { get; set; }

        public int ExecutionCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public class UserReportComparer : IEqualityComparer<UserReportViewModel>
    {
        public bool Equals(UserReportViewModel x, UserReportViewModel y)
        {
            var x_id = x.ReportId;
            var y_id = y.ReportId;

            return Equals(x_id, y_id);
        }

        public int GetHashCode(UserReportViewModel obj)
        {
            return obj.ReportId.GetHashCode();
        }
    }
}