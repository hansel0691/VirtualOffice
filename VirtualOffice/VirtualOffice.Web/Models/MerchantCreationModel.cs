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
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number must be 10 digits long.")]
        public string BusinessPhone { get; set; }
        [Display(Name = "Business Fax")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number must be 10 digits long.")]
        public string BusinessFax { get; set; }
        [Display(Name = "Business DBA")]
        public string DBA { get; set; }
        [Display(Name = "Business Email")]
        public string Email { get; set; }
        [Display(Name = "Cellphone")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number must be 10 digits long.")]
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
        [StringLength(6, MinimumLength = 5, ErrorMessage = "The zip code must be between 5 and 6 digits long.")]
        public string BusinessZip { get; set; }
        [Required]
        [Display(Name = "Guarantor Name")]
        public string GuarantorName { get; set; }
        [Display(Name = "Guarantor Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number must be 10 digits long.")]
        public string GuarantorPhone { get; set; }

    }
}