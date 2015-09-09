using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
        public class OrderConfirmation
        {
            public int OrderConfirmationNumber { get; set; }

            public string Name { get; set; }

            public string Address { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

        }



    public class OrderResponse
    {
        public int OrderId { get; set; }
    }
}