using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOfficeToolManager.Domain
{
    public class PredefinedFilter: Filter
    {

        public int Type { get; set; }

        public string ColumnName { get; set; }

        public string Value { get; set; }

        public string ParameterName { get; set; }
    }
}
