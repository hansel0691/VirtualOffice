using System.Collections.Generic;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models.Orders;

namespace Services.Concrete
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRepository;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _inventoryRepository = unitOfWork.GetRepository<IInventoryRepository>();
        }

        public IEnumerable<InventoryItem> GetItems()
        {
            var items = _inventoryRepository.Get();

            return items;
        }
    }
}
