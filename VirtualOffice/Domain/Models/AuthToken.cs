using System;

namespace Domain.Models
{
    public class AuthToken : BaseModel
    {
        public AuthToken()
        {
            Expiration = DateTime.Now.AddHours(3);
        }

        public string Value { get; set; }

        public int ApiUserId { get; set; }

        public virtual ApiUser ApiUser { get; set; }

        public DateTime Expiration { get; set; }

        public bool IsActive { get; set; }
    }
}