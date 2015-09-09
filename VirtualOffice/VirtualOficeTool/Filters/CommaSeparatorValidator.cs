using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualOficeTool.Filters
{
    public class CommaSeparatorValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var options = value.ToString();

                var filterOptions = options.Trim().Split(',');

                return null;
            }
            catch (Exception)
            {
                return new ValidationResult("The input does not have a comma-separated format");
            }
        }
    }
}