using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class ApiUrls
    {
        #if DEBUG
       
        public const string AUHT_URL = "http://localhost:55893/api/Token/PostToken";
        public const string HOST_URL = "http://localhost:55893";
        public const string LOGIN_URL = "http://localhost:55893/api/User/GetUser";
        public const string API_KEY = "abc";
        public const string API_SECRET = "asdfasdfadfa";
        

#else


        public const string AUHT_URL = "http://virtualofficeservice.pinserve.com/api/Token/PostToken";
        public const string HOST_URL = "http://virtualofficeservice.pinserve.com";
        public const string LOGIN_URL = "http://virtualofficeservice.pinserve.com/api/User/GetUser";
        public const string API_KEY = "abc";
        public const string API_SECRET = "asdfasdfadfa";
#endif
    }
}