using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class Incident
    {
        public int ID { get; set; }
        public int customer_id { get; set; }
        public string Merchant { get; set; }
        public string Incident_Type { get; set; }
        public string Incident_Status { get; set; }
        public string Terminal_Id { get; set; }
        public DateTime Date_Opened { get; set; }
        public DateTime? Date_Closed { get; set; }
    }
}
