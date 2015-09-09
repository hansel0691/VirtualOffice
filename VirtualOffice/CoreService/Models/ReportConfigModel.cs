using System.Collections.Generic;
using Domain.Models;

namespace CoreService.Models
{
    public class ReportConfigModel
    {
        public string ReportName { get; set; }
        
        public IEnumerable<Argument> Args { get; set; }
    }
}