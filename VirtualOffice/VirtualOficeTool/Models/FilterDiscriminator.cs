using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOficeTool.Models
{
    public class FilterDiscriminator
    {
        public FilterDiscriminator(ReportFilterType type)
        {
            Type = type;
        }

        public ReportFilterType Type { get; set; }
    }

    public enum Mode
    {
        Creation, Edition
    }

    public enum ReportFilterType
    {
        UserFilter,PredefinedFilter
    }
}