using System.Collections.Generic;

namespace Domain.Models
{
    public class ReportModel : BaseModel
    {
        public string Name { get; set; }

        public string Query { get; set; }

        public string Output { get; set; }

        public string DefaultOutput { get; set; }

        public string ParamsDefaultConfiguration { get; set; }

        public string UserFilters { get; set; }

        public string IndexColumnName { get; set; }

        public virtual ICollection<ReportPredefinedFilterRel> PredefinedFilters { get; set; }

        public virtual ICollection<ReportToReportRel> SubReports { get; set; }

        public virtual ICollection<ReportToReportRel> ParentReports { get; set; }

        public virtual ICollection<ReportLabel> Labels { get; set; }

        public bool IsEnable { get; set; }

        public bool IsStandAlone { get; set; }

        public string Category { get; set; }
    }
}