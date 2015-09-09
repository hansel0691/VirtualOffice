using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class Document
    {
        public int id_document { get; set; }
        public string file_name { get; set; }
        public string file_title { get; set; }
        public string file_route { get; set; }
        public string typ_description { get; set; }
        public string status { get; set; }
        public DateTime? added_date { get; set; }
        public string added_by { get; set; }
        public DateTime? lastupload_date { get; set; }
        public string lastupload_by { get; set; }
        public DateTime? lastmodified_date { get; set; }
        public string lastmodified_by { get; set; }
        public bool? is_deleted { get; set; }
        public DateTime? deleted_date { get; set; }
        public string deleted_by { get; set; }
        public string comment { get; set; }
        public string comp_name { get; set; }
        public string category { get; set; }
        public string subcategory { get; set; }
    }
}
