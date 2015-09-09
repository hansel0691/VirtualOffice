using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class VirtualOfficeUser
    {
        public int userid { get; set; }
        public string Role { get; set; }
        public string username { get; set; }
        public string businessName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string zipCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public decimal comission { get; set; }
        public int usertype { get; set; }
        public int isFullcarga { get; set; }
    }
}
