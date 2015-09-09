using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VirtualOficeTool.Models
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        [Required]
        //[Remote("IsReportNameAvailable", "Validation", ErrorMessage = "This Report Name is already taken. Please, try a new one.")]
        public string Name { get; set; }

        [Required]
        public string Query { get; set; }

        public bool IsEnable { get; set; }

        public string IndexColumnName { get; set; }

        public bool IsStandAlone { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public List<string> OutPut { get; set; }

        public List<string> ColumnLabels { get; set; } 

        public List<string> Parameter { get; set; }

        public List<string> UserFilters { get; set; }

        public List<int> PredefinedFilters { get; set; }

        public List<int> SubReportIds { get; set; }
        
        public List<string> SubReportColumns { get; set; }

        public List<string> IndexParamNames { get; set; }

        public List<int> Levels { get; set; } 
    }
}