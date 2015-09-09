namespace Domain.Models
{
    public class ReportLabel : BaseModel
    {
        public string ColumnName { get; set; }

        public string Label { get; set; }

        public ReportModel Report { get; set; }

        public int ReportId { get; set; }
    }
}