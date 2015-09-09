using Domain.Models;

namespace CoreData.Models
{
    public class RawInventoryItem 
    {
        public int packageid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? dist_discount { get; set; }

        public string filename { get; set; }

        public double? Weight { get; set; }

        public int? Weight_measureID { get; set; }

        public int? thingID { get; set; }

        public int? thType { get; set; }
    }
}
