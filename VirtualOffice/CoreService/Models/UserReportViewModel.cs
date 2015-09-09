using System;
using System.Collections.Generic;
using CoreService.Controllers;

namespace CoreService.Models
{
    public class UserReportViewModel : ReportConfigViewModel
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }
        
        public string DefaultOuput { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> UserFiltersConfig { get; set; }
        
        public string OutputConfiguration { get; set; }
        
        public int RowCount { get; set; }
        
        public bool ShouldBeShownAtDesktop { get; set; }
        
        public int ExecutionCount { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}