using Domain.Models;

namespace CoreService.Models
{
    public class PredefinedFilterViewModel
    {
        public FilterType Type { get; set; }

        public string FieldName { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
        
        public string ParameterName { get; set; }
        
        public string ColumnName { get; set; }
    }
}