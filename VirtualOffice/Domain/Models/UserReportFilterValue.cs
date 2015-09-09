namespace Domain.Models
{
    public class UserReportFilterValue : BaseModel
    {
        public string Value { get; set; }

        public int UserReportFilterId { get; set; }

        public virtual UserReportFilter UserReportFilter { get; set; }
    }
}