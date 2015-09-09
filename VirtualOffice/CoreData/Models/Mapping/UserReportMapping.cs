using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class UserReportMapping : BaseMapping<UserReport>
    {
        public UserReportMapping()
        {
            this.HasKey(t => new {t.UserId, t.ReportId});

            this.Property(t => t.Output)
                .IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(500);

            this.Property(t => t.OutputConfiguration)
                .IsRequired();

            this.Property(report => report.RowCount)
                .IsRequired();

            this.Property(report => report.ExecutionCount)
                .IsRequired();

            this.Property(report => report.ShouldBeShownAtDesktop)
                .IsRequired();
        }
    }

    public class UserReportFilterMapping : BaseMapping<UserReportFilter>
    {
        public UserReportFilterMapping()
        {
            this.HasKey(t => t.Id);

            this.ToTable("UserReportFilter");

            this.HasRequired(t => t.UserReport)
                .WithMany(t => t.Filters);
        }
    }

    public class UserReportFilterValueMapping : BaseMapping<UserReportFilterValue>
    {
        public UserReportFilterValueMapping()
        {
            this.HasKey(t => t.Id);

            this.ToTable("UserReportFilterValue");

            this.HasRequired(t => t.UserReportFilter)
                .WithMany(t => t.Values);
        }
    }
}