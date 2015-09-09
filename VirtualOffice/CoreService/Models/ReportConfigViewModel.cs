using System.Collections.Generic;
using CoreService.Controllers;
using Domain.Models;

namespace CoreService.Models
{
    public class ReportConfigViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Output { get; set; }
     
        public IEnumerable<PredefinedFilterViewModel> PredefinedFilters { get; set; }
        
        public string UserFilters { get; set; }
        
        public IEnumerable<Parameter> Parameters { get; set; }
        
        public IEnumerable<SubReportConfigModel> SubReport { get; set; }
        
        public IEnumerable<int> ParentReportIds { get; set; }
        
        public string ParamsDefaultConfiguration { get; set; }
        
        public string IndexColumnName { get; set; }
        
        public string ReportName { get; set; }
        
        public bool IsStandAlone { get; set; }
        
        public IEnumerable<LabelViewModel> Labels { get; set; }

        public string Category { get; set; }
    }

    public class SubReportConfigModel
    {
        public int SubReportId { get; set; }

        public string DependencyProperty { get; set; }

        public string IndexParamName { get; set; }
    }
}