using System.ComponentModel.DataAnnotations;

namespace CoreService.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string ApiKey { get; set; }

        [Required]
        public string Signature { get; set; }
    }
}