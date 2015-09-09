using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Domain.Models;

namespace VirtualOffice.Web.Models
{
    public class FilterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Options { get; set; }

        public List<string> Value { get; set; }

        public bool Selected { get; set; }
    }

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