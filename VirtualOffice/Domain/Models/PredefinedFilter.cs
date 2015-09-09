using System.Collections.Generic;

namespace Domain.Models
{
    public class PredefinedFilter : Filter
    {
        public string ColumnName { get; set; }

        public string Value { get; set; }

        public string ParameterName { get; set; }

        public FilterType Type { get; set; }

        public virtual ICollection<ReportPredefinedFilterRel> Reports { get; set; }
    }
}