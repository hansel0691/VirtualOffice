using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models
{
    public class Document
    {
        public string file_name { get; set; }

        public string file_title { get; set; }

        public string category { get; set; }

        public string subcategory { get; set; }
    }

    public enum DocumentCategory
    {
        Agreements,
        AgentForms,
        DistributorForms
    }
}