using System;

namespace Domain.Models
{
    public class NewLead
    {
        public NewLead()
        {
            Company = string.Empty;
            Contact = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Zip = string.Empty;
            Phone = string.Empty;
            CellPhone = string.Empty;
            Fax = string.Empty;
            Notes = string.Empty;
            Source = string.Empty;
            UserAdder = string.Empty;
            mailerID = string.Empty;
            CrossMid = string.Empty;
            other = string.Empty;

            nextVisit = DateTime.Now;
        }

        public string Company { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public int Industry_Id { get; set; }
        public string Notes { get; set; }
        public string Source { get; set; }
        public string UserAdder { get; set; }
        public int UserAdder_empId { get; set; }
        public DateTime nextVisit { get; set; }
        public int typeLead { get; set; }
        public int interested { get; set; }
        public int hear { get; set; }
        public string mailerID { get; set; }
        public int MID { get; set; }

        public string CrossMid { get; set; }
        public string other { get; set; }
        public int language { get; set; }
        public int ext_company_id { get; set; }
        public int ext_user_id { get; set; }
        public int status_id { get; set; }
    }
}