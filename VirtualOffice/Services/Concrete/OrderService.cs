using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Orders;
using IInventoryRepository = Domain.Inventory.IInventoryRepository;

namespace Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IInventoryRepository _inventoryRepository;
        private IRepository<Order> _orderRepository;
        private IUserRepository _userRepository;

        public OrderService(IUnitOfWork unitOfWork, IInventoryRepository inventoryRepository)
        {
            _unitOfWork = unitOfWork;
            _inventoryRepository = inventoryRepository;
            _orderRepository = unitOfWork.Get<Order>();
            _userRepository = unitOfWork.GetRepository<IUserRepository>(); 
        }

        public int AddOrder(CartHeader cart)
        {
            int inventoryOrderId = _inventoryRepository.CreateOrderFrom(cart);
            User user = GetUserFromCart(cart);
            Order order = new Order
                {
                    UserId = user.Id,
                    RefId = inventoryOrderId
                };

            _orderRepository.Add(order);
            _unitOfWork.Commit();

            return order.Id;
        }

        private User GetUserFromCart(CartHeader cart)
        {
            if (cart.AgentID != 0)
            {
                return _userRepository.Get(user => user.RefId == cart.AgentID).FirstOrDefault();
            }
            else
            {
                return _userRepository.Get(user => user.RefId == cart.MerchantId).FirstOrDefault();
            }
        }
    }
}
