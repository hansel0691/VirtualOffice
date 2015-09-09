using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class Lead
    {
        public int Lead_ { get; set; }
        public string createdBy { get; set; }
        public string leadSource { get; set; }
        public int? Emp_ { get; set; }
        public string Assigned_to { get; set; }
        public string Company { get; set; }
        public string Contact_person { get; set; }
        public string Business_address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Business_type { get; set; }
        public string Area_of_Interest { get; set; }
        public DateTime? Entered { get; set; }
        public DateTime? Contacted { get; set; }
        public DateTime? Nxt_Visit { get; set; }
        public DateTime? Closed_on { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int? agentID { get; set; }
    }
}
