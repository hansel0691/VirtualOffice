﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Exceptions
{
    public class InternalServerErrorException: Exception
    {
          public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string message)
            : base(message)
        {
        }

        public InternalServerErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
