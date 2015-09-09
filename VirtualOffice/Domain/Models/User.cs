using System.Collections.Generic;

namespace Domain.Models
{
    public class User : BaseModel
    {
        public int RefId { get; set; }

        public Category Category { get; set; }

        public string BusinessName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal? Comission { get; set; }

        public string Name { get; set; }
        
        public string City { get; set; }
        
        public virtual ICollection<HashKey> Tokens { get; set; }
    }
}