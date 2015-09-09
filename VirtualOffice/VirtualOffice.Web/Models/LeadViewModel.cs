using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class LeadViewModel
    {
        public int? UserAdder_empId { get; set; }
        public string CreatedBy { get; set; }
        public string LeadSource { get; set; }
        public string AssignedTo { get; set; }
        public string ContactPerson { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessType { get; set; }
        public string AreaOfInterest { get; set; }
        public DateTime? Entered { get; set; }
        public DateTime? Contacted { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int? AgentId { get; set; }
        public string Company { get; set; }
        //public string Contact { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public DateTime? NextVisit { get; set; }
    }

    public enum LeadType
    {
        OpenOrInProccess, Closed
    }
}