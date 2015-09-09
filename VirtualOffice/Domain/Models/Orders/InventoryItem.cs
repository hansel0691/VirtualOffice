using System;

namespace Domain.Models.Orders
{
    public class InventoryItem : BaseModel
    {
        public int RefId { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public string filename { get; set; }

        public double? Weight { get; set; }

        public int? Weight_measureID { get; set; }

        public int? thingID { get; set; }

        public int? thType { get; set; }
    }
}
