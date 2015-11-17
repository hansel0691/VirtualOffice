using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class MerchantCreationModel
    {
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public string BusinessPhone { get; set; }
        public string BusinessFax { get; set; }
        public string DBA { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        [Required]
        public string BusinessStreet { get; set; }
        [Required]
        public string BusinessCity { get; set; }
        [Required]
        public string BusinessState { get; set; }
        [Required]
        public string BusinessZip { get; set; }
        [Required]
        public string GuarantorName { get; set; }
        public string GuarantorPhone { get; set; }

    }
}