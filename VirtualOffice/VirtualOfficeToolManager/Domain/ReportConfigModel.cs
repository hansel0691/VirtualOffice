using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace VirtualOfficeToolManager.Domain
{
    public class ReportConfigModel
    {
        public string ReportName { get; set; }
        public IEnumerable<Argument> Args { get; set; }
    }
}
