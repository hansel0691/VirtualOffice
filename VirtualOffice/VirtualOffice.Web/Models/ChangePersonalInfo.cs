using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class ChangePersonalInfo
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DBA { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}