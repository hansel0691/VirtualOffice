using System;
using System.Collections.Generic;

namespace Domain.Models.Orders
{
    public class CartHeader
    {
        public IEnumerable<CartItem> Items { get; set; }

        public ShippingInfo ShippingInfo { get; set; }

        public int MerchantId { get; set; }

        public double TotalWeight { get; set; }

        public int WeightId { get; set; }

        public decimal Total { get; set; }
        
        public decimal Tax { get; set; }
        
        public decimal Discount { get; set; }
        
        public decimal Net { get; set; }
        
        public int DeploymentId { get; set; }

        public int AgentID { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Extended { get; set; }

        public decimal Discount { get; set; }

        public decimal Tax { get; set; }

        public string Unit { get; set; }

        public double Weight { get; set; }

        public int WeightId { get; set; }
    }

    public class ShippingInfo 
    {
        public string To { get; set; }
        
        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public bool FedExHomeDelivery { get; set; }

        public bool FedExSaturdayDelivery { get; set; }

        public short ShippingType { get; set; }

        public decimal Cost { get; set; }
    }
}