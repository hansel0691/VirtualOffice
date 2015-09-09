using System.Collections.Generic;

namespace Domain.Models
{
    public class ApiUser : BaseModel
    {
        public string ApiKey { get; set; }

        public string Secret { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<AuthToken> Tokens { get; set; }
    }
}