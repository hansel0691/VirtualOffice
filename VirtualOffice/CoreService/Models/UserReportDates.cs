using System;

namespace CoreService.Models
{
    public class UserReportDates
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}