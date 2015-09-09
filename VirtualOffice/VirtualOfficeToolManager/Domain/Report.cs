using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOfficeToolManager.Domain
{
    public class Report
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Query { get; set; }
     
        //(Comma- Separated)
        public string OutPut { get; set; }

        public string OutPutConfiguration { get; set; }
        
        //(Comma- Separated)
        public string ColumnLabels { get; set; }

        //(Comma- Separated)
        public string Levels { get; set; }

        //(Comma- Separated)
        public string ParamsDefaultConfiguration { get; set; }

        //(Comma- Separated)
        public string UserFilters { get; set; }

        public string IndexColumnName { get; set; }

        public string Category { get; set; }

        public bool IsEnable { get; set; }

        public bool IsStandAlone { get; set; }
        
        public List<int> PredefinedFilters { get; set; }

        public List<SubReport> SubReports { get; set; } 

        public DateTime TimeSpan { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
