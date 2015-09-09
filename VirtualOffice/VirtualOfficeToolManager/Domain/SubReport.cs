using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOfficeToolManager.Domain
{
    public class SubReport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ColumnName { get; set; }

        public string IndexParamName { get; set; }
    }
}
