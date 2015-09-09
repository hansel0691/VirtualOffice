using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using CoreService.Binder;
using Domain.Infrastructure.Services;
using Domain.Models.Orders;
using RestSharp;

namespace CoreService.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IHttpActionResult Add([ModelBinder(typeof (DataBinder))] CartHeader cartModel)
        {
            int result = _orderService.AddOrder(cartModel);


            return Ok(new {OrderId = result});
        }

        [HttpGet]
        public IHttpActionResult TestAdd()
        {
            var result = Add(new CartHeader
            {
                AgentID = 2272,
                DeploymentId = 0,
                Discount = 0,
                MerchantId = 0,
                Net = 0,
                Tax = 0,
                Total = 15,
                TotalWeight = 0.062,
                WeightId = 0,
                
                ShippingInfo = new ShippingInfo
                {
                    To = "ePREPAID NETWORK, INC.",
                    AddressOne = "11270 SW 157 CT",
                    AddressTwo = "",
                    City = "MIAMI",
                    State = "FL",
                    ZipCode = "33196",
                    Country = "USA",
                    Phone = "7864570621",
                    Email = "eprepaid@comcast.net",
                    Notes = "",
                    Cost = 15
                },
                Items = new List<CartItem>
                        {
                            new CartItem
                                {
                                    Id = 193,
                                    Weight = 0.01,
                                    WeightId = 4,
                                    Price = 0m,
                                    Quantity = 1,
                                    Description = "AT&T Handset Plan Poster 11 x 17",
                                    Unit = "Units",
                                    Type = ""
                                },
                                new CartItem
                                {
                                    Id = 172,
                                    Weight = 0.05,
                                    WeightId = 4,
                                    Price = 0m,
                                    Quantity = 1,
                                    Description = "Digicel Poster 22 x 24",
                                    Unit = "Units",
                                    Type = ""
                                },
                                  new CartItem
                                {
                                    Id = 191,
                                    Weight = 0.001,
                                    WeightId = 4,
                                    Price = 0m,
                                    Quantity = 2,
                                    Description = "Metel Cuba Rate Poster 8.5 x 11",
                                    Unit = "Units",
                                    Type = ""
                                }
                        }
            });




            //var result = Add(new CartHeader
            //    {
            //        AgentID = 2272,
            //        DeploymentId = 0,
            //        Discount = 0,
            //        MerchantId = 0,
            //        Net = 5,
            //        Tax = 0,
            //        Total = 3.50m,
            //        TotalWeight = 5,
            //        WeightId = 4,
            //        ShippingInfo = new ShippingInfo
            //            {
            //                AddressOne = "14214",
            //                City = "Miami",
            //                Cost = 0,
            //                Country = "US",
            //                ZipCode = "33183",
            //                State = "FL",
            //                Notes = "test order",
            //            },
            //        Items = new List<CartItem>
            //            {
            //                new CartItem
            //                    {
            //                        Id = 2,
            //                        Weight = 0.5,
            //                        Price = 3.50m
            //                    },
            //                new CartItem
            //                    {
            //                        Id = 3,
            //                        Weight = 0.5,
            //                    }

            //            }
            //    });

            return result;
        }
    }
}
