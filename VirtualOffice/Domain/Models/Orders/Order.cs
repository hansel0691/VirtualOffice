﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Models.Orders
{
    public class Order : BaseModel
    {
        public User User { get; set; }

        public int RefId { get; set; }

        public int UserId { get; set; }
    }
}
