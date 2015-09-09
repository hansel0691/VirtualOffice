using System;
using CoreData.Inventory.Models;
using Domain.Inventory;
using Domain.Models.Exceptions;
using Domain.Models.Orders;

namespace CoreData.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        public int CreateOrderFrom(CartHeader cartHeader)
        {
            try
            {
                using (POSInventoryContext context = new POSInventoryContext())
                {
                    int cHeaderId = AddCartHeader(cartHeader, context);
                    AddCartDetails(cartHeader, cHeaderId, context);
                    
                    var orderId = AddOrder(cartHeader, context, cHeaderId);

                    return orderId;
                }
            }
            catch (Exception e)
            {
                throw new DataAccessException("Error POSInventoryContext access", e);
            }
        }

        private int AddOrder(CartHeader cartHeader, POSInventoryContext context, int cHeaderId)
        {
            int orderId = context.InsertOrder(
                cHeaderId,
                cartHeader.AgentID,
                cartHeader.DeploymentId,
                0,
                cartHeader.ShippingInfo.To,
                cartHeader.ShippingInfo.AddressOne,
                cartHeader.ShippingInfo.AddressTwo,
                cartHeader.ShippingInfo.City,
                cartHeader.ShippingInfo.State,
                cartHeader.ShippingInfo.ZipCode,
                cartHeader.ShippingInfo.Country,
                cartHeader.ShippingInfo.Phone,
                cartHeader.Tax,
                cartHeader.Discount,
                cartHeader.Net,
                cartHeader.ShippingInfo.FedExHomeDelivery,
                cartHeader.ShippingInfo.FedExSaturdayDelivery,
                cartHeader.ShippingInfo.Email
                );
            return orderId;
        }

        private void AddCartDetails(CartHeader cartHeader, int cHeaderId, POSInventoryContext context)
        {
            foreach (var cartItem in cartHeader.Items)
            {
                Cart_Detail cDetail = new Cart_Detail
                    {
                        cart_id = cHeaderId,
                        thType = cartItem.Type,
                        thingID = cartItem.Id,
                        description = cartItem.Description,
                        qty = cartItem.Quantity,
                        price = cartItem.Price,
                        extended = cartItem.Extended,
                        discount = cartItem.Discount,
                        tax = cartItem.Tax,
                        unit = cartItem.Unit,
                        weight = cartItem.Weight,
                        weight_measureID = cartItem.WeightId
                    };

                context.InsertCartDetails(cDetail);
            }

            context.SaveChanges();
        }

        private int AddCartHeader(CartHeader cartHeader, POSInventoryContext context)
        {
            Cart_Header cHeader = new Cart_Header
                {
                    dateadded = DateTime.Now,
                    agentID = cartHeader.AgentID,
                    merchant_fk = cartHeader.MerchantId,
                    order_total = cartHeader.Total,
                    order_tax = cartHeader.Tax,
                    order_discount = cartHeader.Discount,
                    order_net = cartHeader.Net,
                    orShipTo = cartHeader.ShippingInfo.To,
                    orShipAddress1 = cartHeader.ShippingInfo.AddressOne,
                    orShipAddress2 = cartHeader.ShippingInfo.AddressTwo,
                    orShipCity = cartHeader.ShippingInfo.City,
                    orShipState = cartHeader.ShippingInfo.State,
                    orShipZipCode = cartHeader.ShippingInfo.ZipCode,
                    orShipCountry = cartHeader.ShippingInfo.Country,
                    orShipPhone = cartHeader.ShippingInfo.Phone,
                    orRefNotes = cartHeader.ShippingInfo.Notes,
                    FedExHomeDelivery = cartHeader.ShippingInfo.FedExHomeDelivery,
                    FedExSaturdayDelivery = cartHeader.ShippingInfo.FedExSaturdayDelivery,
                    orShipCost = cartHeader.ShippingInfo.Cost,
                    orShipEmail = cartHeader.ShippingInfo.Email,
                    orTotalWeight = cartHeader.TotalWeight,
                    orWeight_measureID = cartHeader.WeightId,
                    deploymethID = cartHeader.DeploymentId,
                };

            int cHeaderId = context.InsertCartHeader(cHeader);
            
            return cHeaderId;
        }

    }
}
