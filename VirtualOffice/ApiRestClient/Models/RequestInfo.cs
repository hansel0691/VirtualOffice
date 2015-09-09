using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ApiRestClient.Models
{
    public class RequestInfo
    {
        public string AuthUrl { get; set; }
        public string RequestUrl { get; set; }
        public Method Method { get; set; }
    }
}
