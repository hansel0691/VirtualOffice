using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain
{
    public class DashboardItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Dictionary<string, string> Items { get; set; }
        public string ItemsFunction { get; set; }
        public string Remark { get; set; }
        public DashboardItemType DashboardItemType { get; set; }
        public string LinkUrl { get; set; }
    }

    public enum DashboardItemType
    {
        MerchantServices, Prepaid
    }
}
