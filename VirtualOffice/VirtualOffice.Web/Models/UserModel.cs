using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string UserCategory { get; set; }

        public int EmployeeId { get; set; }

        public string BusinessName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public decimal Comission { get; set; }
        public bool IsFullcarga { get; set; }

    }
}