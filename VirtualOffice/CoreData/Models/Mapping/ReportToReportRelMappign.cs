using System.Data.Entity.ModelConfiguration;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class ReportToReportRelMappign : EntityTypeConfiguration<ReportToReportRel>
    {
        public ReportToReportRelMappign()
        {
            this.HasKey(t => new {t.FromId, t.ToId});

            this.Property(t => t.DependencyProperty)
                .IsRequired();

            this.ToTable("ReportToReportRel");

            this.HasRequired(t => t.From)
                .WithMany(report => report.SubReports);

            this.HasRequired(t => t.To)
                .WithMany(report => report.ParentReports);
        }
    }
}