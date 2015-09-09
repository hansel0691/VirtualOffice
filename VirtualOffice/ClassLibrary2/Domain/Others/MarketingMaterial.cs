using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Domain.Others
{
    public class MarketingMaterial
    {
        public string Name { get; set; }
        public int packageid { get; set; }
        public decimal? Price { get; set; }
        public decimal Discount { get; set; }
        public string FileName { get; set; }
        public double? Weight { get; set; }
        public int? Weight_measureID { get; set; }
        public int? thingID { get; set; }
        public int? thType { get; set; }
        public string Category { get; set; }
    }
}
