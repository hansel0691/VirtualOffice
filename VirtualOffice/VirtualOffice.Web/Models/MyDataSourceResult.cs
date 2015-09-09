using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class MyDataSourceResult
    {
        public IEnumerable Data { get; set; }

        public int Total { get; set; }

        public object Errors { get; set; }

        public IEnumerable<MyAggregateResult> AggregateResults { get; set; } 
    }

    public class MyAggregateResult
    {
        public string AggregateMethodName { get; set; }

        public string FunctionName { get; set; }

        public object Value { get; set; }

        public object FormattedValue { get; set; }

        public string Member { get; set; }

        public string Caption { get; set; }

        public int ItemCount { get; set; }
    }
}