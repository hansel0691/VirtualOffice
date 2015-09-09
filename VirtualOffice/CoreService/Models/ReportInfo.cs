using System.Collections.Generic;
using Domain.Models;

namespace CoreService.Models
{
    public class ReportInfoModel
    {
        public int ReportId { get; set; }
        public IEnumerable<Argument> Args { get; set; } 
    }
}