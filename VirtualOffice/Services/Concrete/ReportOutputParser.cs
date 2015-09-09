using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Services;

namespace Services.Concrete
{
    public class ReportOutputParser : IOutputParser
    {
        public IEnumerable<string> Parse(string output)
        {
            string[] items = output.Split(',');

            return items;
        }
    }
}
