using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOficeTool.Models
{
    public class ReportColumn
    {
        public string Name { get; set; }

        public bool Selected { get; set; }

        public bool Filterable { get; set; } 
         
        public int Width { get; set; }

        public int Index { get; set; }

        public bool IsIndex { get; set; }

        public string Label { get; set; }

        public int Level { get; set; }
    }
}