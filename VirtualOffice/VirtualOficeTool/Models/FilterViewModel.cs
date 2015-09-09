using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VirtualOficeTool.Filters;

namespace VirtualOficeTool.Models
{
    public class FilterViewModel
    {
        public int Id { get; set; }

        [Required]
       // [Remote("IsFilterNameAvailable", "Validation", ErrorMessage = "This Filter Name is already taken. Please, try a new one.")]
        public string Name { get; set; }

        public bool Selected { get; set; }
    }

    public class UserFilterViewModel: FilterViewModel
    {
        [Required]
        public string Label { get; set; }

    }

    public class PredefinedFilterViewModel : FilterViewModel
    {
        [Required]
        public string Type { get; set; }

        public string Value { get; set; }

        [Required]
        public string ColumnName { get; set; }

        [Required]
        public string ParameterName { get; set; }
    }
}