using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class DateRange
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public class SummaryRange
    {
        public int Month { get; set; }

        public int Year { get; set; }

    }

    public enum Month
    {
        January, February, March, April, May, June, July, August, September, October, November, December
    }

    public enum SummaryRangeOption
    {
        Last12Months = 12, Last9Months = 9, Last6Months = 6
    }
}