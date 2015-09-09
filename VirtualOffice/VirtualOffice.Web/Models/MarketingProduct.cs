using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models.Orders;

namespace VirtualOffice.Web.Models
{
    public class MarketingProduct: InventoryItem
    {
        public MarketingProduct(InventoryItem item, string category, int quantity = 0)
        {
            Id = item.RefId;
            Category = category;
            Price = item.Price;
            Weight = item.Weight;
            Weight_measureID = item.Weight_measureID;
            filename = item.filename;
            Discount = item.Discount;
            thType = item.thType;
            thingID = item.thingID;
            Quantity = quantity;
            Name = item.Name;
        }

        public MarketingProduct() { }

        public string Category { get; set; }

        public int Quantity { get; set; }
    }
}