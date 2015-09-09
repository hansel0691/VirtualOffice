using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Contexts;
using CoreData.Helpers;
using Domain.Infrastructure.Repositories;
using Domain.Models.Orders;

namespace CoreData.Concrete
{
    public class SqlInventoryRepository : Repository<InventoryItem>, IInventoryRepository
    {
        private readonly VirtualOfficeContext _context;

        public SqlInventoryRepository(VirtualOfficeContext context) 
            : base(context.Set<InventoryItem>())
        {
            _context = context;
        }

        public IEnumerable<InventoryItem> Get()
        {
            var items = _context.GetInventoryItems().Select(item => item.ToDomain());

            return items;
        }
    }
}