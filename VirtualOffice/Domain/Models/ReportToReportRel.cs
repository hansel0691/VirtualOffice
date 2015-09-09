namespace Domain.Models
{
    public class ReportToReportRel : BaseUModel
    {
        public int FromId { get; set; }
        public int ToId { get; set; }

        public virtual ReportModel From { get; set; }
        public virtual ReportModel To { get; set; }

        public string DependencyProperty { get; set; }

        public string IndexParamName { get; set; }
    }
}