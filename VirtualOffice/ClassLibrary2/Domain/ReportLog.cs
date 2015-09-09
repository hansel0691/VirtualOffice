using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain
{
    public class ReportLog
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public DateTime? TimeSpan { get; set; }
        public int? ReportCount { get; set; }
        public string ErrorMessage { get; set; }
        public string AgentId { get; set; }
    }
}
