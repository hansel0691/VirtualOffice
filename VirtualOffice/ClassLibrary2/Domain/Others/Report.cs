using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class Report
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public bool IsEnable { get; set; }
        public DateTime TimeSpan { get; set; }
        public string Output { get; set; }
        public string Name { get; set; }
        public string DefaultOutput { get; set; }
        public byte[] RowVersion { get; set; }
        public string ParamsDefaultConfiguration { get; set; }
        public string UserFilters { get; set; }
        public string IndexColumnName { get; set; }
        public bool IsStandAlone { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
    }
}
