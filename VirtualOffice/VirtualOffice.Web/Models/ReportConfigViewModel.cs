using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Domain.Models;
using VirtualOffice.Web.Infrastructure;

namespace VirtualOffice.Web.Models
{
    public class ReportConfigViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Output { get; set; }
        public string IndexColumnName { get; set; }

        public List<ReportColumn> Columns { get; set; }

        public List<LabelViewModel> Labels { get; set; }
       
        public List<PredefinedFilterViewModel> PredefinedFilters { get; set; }

        public string UserFilters { get; set; }

        public List<Parameter> Parameters { get; set; }

        public List<Argument> ExtraArguments { get; set; } 
         
        public List<SubReportConfigModel> SubReport { get; set; }

        public List<int> ParentReportIds { get; set; }

        public string ParamsDefaultConfiguration { get; set; }

        public string Category { get; set; }
        
        public bool IsStandAlone { get; set; }

        public bool IsFilterableByDate
        {
            get
            {
                if (Parameters.IsNull())
                    return false;

                var startDateParameter = Parameters.FirstOrDefault(param =>param.Name.IsLike(Utils.StartDateSubstring));
                var endDateDateParameter = Parameters.FirstOrDefault(param => param.Name.IsLike(Utils.EndDateSubstring));

                return !startDateParameter.IsNull() && !endDateDateParameter.IsNull();
            }
        }

        public IEnumerable<ExpandoObject> Data { get; set; } 
    }

    public class SubReportConfigModel
    {
        public int SubReportId { get; set; }

        public string DependencyProperty { get; set; }

        public string IndexParamName { get; set; }
    }
}