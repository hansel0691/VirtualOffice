using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace VirtualOffice.Web.Models
{
    public class ColumnConfig
    {
        public int Index { get; set; }
        public int Width { get; set; }
        public int Level { get; set; }
        public bool Hidden { get; set; }
        public string Link { get; set; }
        public string Label { get; set; }
        public bool IsNumeric { get; set; }
        public bool IsDate { get; set; }
        public bool Groupable { get; set; }
    }
}