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
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string DBA { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}