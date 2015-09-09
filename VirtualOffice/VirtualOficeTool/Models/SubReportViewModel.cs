using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOficeTool.Models
{
    public class SubReportViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ColumnName { get; set; }

        public string IndexParamName { get; set; }

        public bool Selected { get; set; }
    }
}
