using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class CloudContainer
    {
        public CloudInfoModel item1 { get; set; }
    }

    public class CloudInfoModel
    {
        public string Title { get; set; }

        public int Id { get; set; }
       
        public string Category { get; set; }
        
        public int Items { get; set; }
        
        public string Color { get; set; }
        
        public int Width { get; set; }
       
        public int Height { get; set; }

        public string Url { get; set; }
        
    }
}