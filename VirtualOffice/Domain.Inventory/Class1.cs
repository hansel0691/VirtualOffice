using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Orders;

namespace Domain.Inventory
{
    public interface IInventoryRepository
    {
        int CreateOrderFrom(CartHeader cartHeader);
    }
}
