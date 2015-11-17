using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Prepaid
{
    public class CommissionByProductReport
    {
        public string merproduct_sbt { get; set; }
        public string pro_description { get; set; }
        public string Product_MainCode { get; set; }
        public float mercomm { get; set; }
        public float agentcomm { get; set; }
        public float distcomm { get; set; }
        public float isocomm { get; set; }
    }
}
