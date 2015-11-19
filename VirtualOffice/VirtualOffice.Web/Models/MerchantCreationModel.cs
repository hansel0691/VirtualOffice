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
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
        [Required]
        [Display(Name = "Business Phone")]
        public string BusinessPhone { get; set; }
        [Display(Name = "Business Fax")]
        public string BusinessFax { get; set; }
        [Display(Name = "Business DBA")]
        public string DBA { get; set; }
        [Display(Name = "Business Email")]
        public string Email { get; set; }
        [Display(Name = "Cellphone")]
        public string CellPhone { get; set; }
        [Required]
        [Display(Name = "Business Street")]
        public string BusinessStreet { get; set; }
        [Required]
        [Display(Name = "Business City")]
        public string BusinessCity { get; set; }
        [Required]
        [Display(Name = "Business State")]
        public string BusinessState { get; set; }
        [Required]
        [Display(Name = "Business Zip")]
        public string BusinessZip { get; set; }
        [Required]
        [Display(Name = "Guarantor Name")]
        public string GuarantorName { get; set; }
        [Display(Name = "Guarantor Phone Number")]
        public string GuarantorPhone { get; set; }

    }
}