using System;

namespace Domain.Models
{
    public class Parameter : IComparable<Parameter>
    {
        public string Name { get; set; }
        public string Type { get; set; }
       
        public int CompareTo(Parameter other)
        {
            return String.Compare(Name, other.Name, System.StringComparison.Ordinal);
        }
    }
}
