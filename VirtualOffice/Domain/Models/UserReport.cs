using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class UserReport : BaseUModel
    {
        public int UserId { get; set; }

        public int ReportId { get; set; }

        public string Output { get; set; }

        public string OutputConfiguration { get; set; }

        public virtual User User { get; set; }

        public virtual ReportModel Report { get; set; }
        
        public string Name { get; set; }

        public int ExecutionCount { get; set; }

        public int RowCount { get; set; }

        public bool ShouldBeShownAtDesktop { get; set; }

        public virtual ICollection<UserReportFilter> Filters { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}