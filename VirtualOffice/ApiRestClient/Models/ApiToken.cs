using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestClient.Models
{
    public class ApiToken
    {
        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }
    }
}
