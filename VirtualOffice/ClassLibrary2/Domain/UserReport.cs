using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice.Service.Domain
{
    public class UserReport
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public string Output { get; set; }
        public System.DateTime TimeSpan { get; set; }
        public byte[] RowVersion { get; set; }
        public string Name { get; set; }
        public string OutputConfiguration { get; set; }
        public int ExecutionCount { get; set; }
        public int RowCount { get; set; }
        public bool ShouldBeShownAtDesktop { get; set; }
    }
}
