using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class UserReportFilter : BaseModel, IComparable<UserReportFilter>
    {
        public string ColunmName { get; set; }

        public virtual UserReport UserReport { get; set; }

        public virtual ICollection<UserReportFilterValue> Values { get; set; }
        
        public bool Deleted { get; set; }

        public int CompareTo(UserReportFilter other)
        {
            if (ColunmName != other.ColunmName)
            {
                return -1;
            }

            if (this.Values.Count != other.Values.Count)
            {
                return -1;
            }
            else
            {
                foreach (var value in Values)
                {
                    if (!other.Values.Contains(value))
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }
    }
}