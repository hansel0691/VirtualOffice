using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Domain.Models.Orders;

namespace Domain.Infrastructure.Repositories
{
    public interface IInventoryRepository : IRepository<InventoryItem>
    {
        IEnumerable<InventoryItem> Get();

      
    }
}