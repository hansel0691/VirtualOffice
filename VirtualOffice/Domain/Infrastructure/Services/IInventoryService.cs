using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Orders;

namespace Domain.Infrastructure.Services
{
    public interface IInventoryService
    {
        IEnumerable<InventoryItem> GetItems();
    }
}
