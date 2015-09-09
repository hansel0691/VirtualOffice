namespace CoreService.Models
{
    public class UserReportConfigurationModel
    {
        public int UserId { get; set; }

        public int ReportId { get; set; }

        public bool ShowReportOnDesktop { get; set; }
    }
}