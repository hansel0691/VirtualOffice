using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class ReportPredefinedFilterRelMapping : BaseMapping<ReportPredefinedFilterRel>
    {
        public ReportPredefinedFilterRelMapping()
        {
            this.HasKey(t => new {t.ReportId, t.FilterId});

            this.HasRequired(t => t.Filter)
                .WithMany(filter => filter.Reports);

            this.HasRequired(t => t.Report)
                .WithMany(report => report.PredefinedFilters);
        }
    }
}