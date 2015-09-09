using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class ReportMapping : BaseMapping<ReportModel>
    {
        public ReportMapping()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.RowVersion).IsConcurrencyToken();
            this.Property(t => t.TimeSpan).IsRequired();

            this.Property(t => t.Query).IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired(); //make index

            this.Property(t => t.Output)
                .HasMaxLength(5000)
                .IsRequired();

            this.Property(t => t.UserFilters)
                .HasMaxLength(5000);

            this.Property(t => t.DefaultOutput)
                .HasMaxLength(5000)
                .IsRequired();

            this.Property(t => t.IndexColumnName)
                .HasMaxLength(5000);

            this.ToTable("Reports");
        }
    }

    public class ReportLabelMapping : BaseMapping<ReportLabel>
    {
        public ReportLabelMapping()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.ColumnName)
                .IsRequired();

            this.Property(t => t.Label)
                .IsRequired();

            this.ToTable("ReportLabels");

            this.HasRequired(t => t.Report)
                .WithMany(report => report.Labels);
        }
    }

}
