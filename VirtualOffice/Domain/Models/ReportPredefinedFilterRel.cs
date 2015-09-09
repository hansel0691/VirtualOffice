namespace Domain.Models
{
    public class ReportPredefinedFilterRel : BaseUModel
    {
        public int ReportId { get; set; }
        public int FilterId { get; set; }

        public virtual ReportModel Report { get; set; }
        public virtual PredefinedFilter Filter { get; set; }
    }
}