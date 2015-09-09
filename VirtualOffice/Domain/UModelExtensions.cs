using System;
using System.Text;
using Domain.Models;

namespace Domain
{
    internal static class UModelExtensions
    {
        public static string ToString(this BaseUModel model)
        {
            if (model == null)
            {
                return string.Empty;
            }

            StringBuilder strBuilder = new StringBuilder();

            var modelProperties = model.GetType().GetProperties();

            foreach (var property in modelProperties)
            {
                try
                {
                    object value = property.GetValue(model);

                    strBuilder.Append(string.Format("{0} : {1} \n", property.Name, value));
                }
                catch (Exception e)
                {
                    strBuilder.Append(string.Format("Exception: {0} thrown when getting value of property: {1} \n", e, property.Name));
                }
            }

            return strBuilder.ToString();
        }
    }
}