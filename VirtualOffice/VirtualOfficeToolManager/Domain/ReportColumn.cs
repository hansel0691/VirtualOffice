using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOfficeToolManager.Domain
{
    public class ReportColumn
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public int Width { get; set; }

        public int Index { get; set; }

        public int Level { get; set; }
    }
}