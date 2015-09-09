using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class ChangePasswordModel
    {
        public int UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}