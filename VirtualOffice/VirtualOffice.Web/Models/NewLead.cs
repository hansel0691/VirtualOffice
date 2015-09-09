using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Models;

namespace VirtualOffice.Web.Models
{
    public class NewLeadViewModel
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}" )]
        public string Phone { get; set; }
        
        public string CellPhone { get; set; }
        public string BussinessPhone { get; set; }
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
        public int status_id { get; set; }
        public string CrossMid { get; set; }
        public string other { get; set; }
        public int language { get; set; }
        public int ext_company_id { get; set; }
        public int ext_user_id { get; set; }
    }

    public class AddNewLeadResponse
    {
        public int LeadId { get; set; }
    }
}