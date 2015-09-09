using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
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
}
