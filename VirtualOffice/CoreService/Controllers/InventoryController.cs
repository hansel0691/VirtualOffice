using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Infrastructure.Services;

namespace CoreService.Controllers
{
    public class InventoryController : ApiController
    {
        private IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IHttpActionResult GetItems()
        {
            var items = _inventoryService.GetItems();

            return Ok(items);
        }
    }
}
